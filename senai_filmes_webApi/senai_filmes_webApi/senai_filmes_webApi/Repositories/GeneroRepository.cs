using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// initial catalog = Nome do banco de dados
        /// user Id=sa; pwd=senai@132 = Faz a autenticação com o usuário do SQL Server, passando o logon e a senha
        /// integrated security=true = Faz a autenticação com o usuário do sistema (Windows)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-DFS5ABT\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=senai@132";
        //private string stringConexao = "Data Source=DESKTOP-SP7RV1S\\SQLEXPRESS; initial catalog=Filmes; integrated security=true";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            // declara a SqlConnection con passando a string de conexão como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada 
                string queryUpdateIdBody = "Update Generos Set Nome = @Nome Where idGenero = @ID";

                // declara o SqlCommand cmd passando a query que será executada e a conexao como paramentro
                using (SqlCommand cmd = new SqlCommand(stringConexao))
                {
                    // passando os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@ID", genero.  idGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    // abrindo conexão com o banco
                    con.Open();

                    // executa o comando 
                    cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// atualiza um gênero passando po id pelo recuso (URL)
        /// </summary>
        /// <param name="id"> id do gênero que será atualizado</param>
        /// <param name="genero"> objeto gênero com as novas informações</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            // declara a SqlConnection con passando a string de conexão como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada 
               string queryUpdateIdUrl = "Update Generos Set Nome = @Nome Where idGenero = @ID";

                // declara o SqlCommand cmd passando a query que será executada e a conexao como paramentro
                using (SqlCommand cmd = new SqlCommand(stringConexao))
                {
                    // passando os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    // abrindo conexão com o banco
                    con.Open();

                    // executa o comando 
                    cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// busca um gênero atrvés do seu id 
        /// </summary>
        /// <param name="id"> id do gênero que será buscado</param>
        /// <returns> um gênero buscado ou null caso não seja encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada
                string querySelectById = "Select idGenero, nome From Generos Where idGenero = @Id";

                // abre a conexão com o bamco de dados
                con.Open();

                // declara o SqlDataReader para receber os valores do banco de dados
                SqlDataReader rdr;

                // declara o SqlCommand cmd passando a query que será executada e a conexão com parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // executa a query e armazena os dados rdr
                    rdr = cmd.ExecuteReader();

                    // verifica se o resultado da query retorna algum registro
                    if (rdr.Read())
                    {
                        // se dim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            // atribiu a propriedade idGenero o valor da coluna "idGenero" da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),

                            // atribiu à propriedade nome o valor da coluna "nome" da tabela do banco de dados
                            nome = rdr["nome"].ToString()
                        };

                        // retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }

                    // se não, retorna null
                    return null; 
                }
            }
        }

        /// <summary>
        /// cadastra um novo gênero 
        /// </summary>
        /// <param name="novoGenero"> objeto novoGenero com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // declara a conexão con passando a string de conexão como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a query que será executada
                // insert into Generos(nome) values ('Ficção cientifica');
                // insert into Generos(nome) values ('Joana D'Arc');
                // insert into Generos(nome) values ('')Drop Table Filmes--  
                //string queryInsert = "insert into Generos(nome) values ('" + novoGenero.nome +  "')";
                // não usar dessa forma, pois pode causar o efeito Joana D'Arc
                // além de permitir Sql Injection
                // por exemplo
                // "nome" : "Perdeu mané") Drop Table filmes--"
                // ao tentar cadastrar o comando acima, irá deletar a tabela filmes do banco de dados

                // declara a query que será executada
                string queryInsert = "insert into Generos(nome) values (@Nome)";

                // declara o SqlCommand cmd passando a query que será executada e a conexão com paramentros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // passa o valor do parâmetro @Nome
                     cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    // abre a conexão com o banco de dados
                    con.Open();

                    // executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// deleta um gênero através do seu id
        /// </summary>
        /// <param name="id"> id do gênero que será deletado</param>
        public void Deletar(int id)
        {
            // declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao) )
            {
                // declara a query a ser executada passando o parametro @ID
                string queryDelete = "Delete From Generos Where idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // abre a conexão com o banco de dados
                    con.Open();

                    // executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista listaGeneros onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui à propriedade idGenero o valor da primeira coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString()
                        };

                        // Adiciona o objeto genero criado à lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }

            // Retorna a lista de gêneros
            return listaGeneros;
        }
        
    }

}

