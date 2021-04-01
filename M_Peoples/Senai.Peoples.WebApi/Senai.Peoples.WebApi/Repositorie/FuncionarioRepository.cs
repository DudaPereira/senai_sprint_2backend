using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositorie
{
    /// <summary>
    /// classe responsável pelo repositório dos funcionarios
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// initial catalog = Nome do banco de dados
        /// user Id=sa; pwd=senai@132 = Faz a autenticação com o usuário do SQL Server, passando o logon e a senha
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-DFS5ABT\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=senai@132";

        /// <summary>
        /// atualiza um funcionario passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id"> id do funcionario que será atualizado</param>
        /// <param name="funcionario"> objeto funcionario com as novas informações</param>
        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            // declara a SqlConnection con passado a string de conexão como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada
                string queryUpdateIdUrl = "update Funcionarios set NomeFuncio = @Nome where idFuncionario = @ID";

                // declara o SqlCommand cmd passando a query que será executada e a conexão como parametro
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // passa o valor para o parametro @Id
                    cmd.Parameters.AddWithValue("@Nome", funcionario.nome);

                    // abre a conexão com o banco
                    con.Open();

                    // executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// busca um funcionario através do seu id
        /// </summary>
        /// <param name="id"> id do funcionario que será buscado</param>
        /// <returns> um funcionario buscado ou null caso não seja encontrado</returns>
        public FuncionarioDomain BuscaPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada
                string querySelectById = "select idFuncionario, nomeFuncio, sobrenomeFuncio, dataNasci from Funcionarios where idFuncionario = @ID";

                // abre a conexão com o banco
                con.Open();

                // declara o SqlDataReader rdr para receber os valores do banco
                SqlDataReader rdr;

                // declara o SqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // verifica se o resultado da query retornou algum registro 
                    if (rdr.Read())
                    {
                        // se sim, instancia um novo objeto funcionarioBuscado do tipo FuncionarioDomain
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            // atribui à propriedade idFuncionario o valor da coluna "idFuncionario" da tabela do banco
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            // atribui à propriedade nome o valor da coluna "NomeFuncio" da tabela do banco 
                            nome = rdr["NomeFuncio"].ToString(),

                            // atribui à propriedade sobrenome o valor da coluna "SobrenomeFuncio" da tabela do banco
                            sobrenome = rdr["SobrenomeFuncio"].ToString(),

                            // atribui à propriedade dataNasci o valor da coluna "DataNasci" da tabela do banco
                            dataNasci = Convert.ToDateTime(rdr["DataNasci"])
                        };

                        // retorna o funcionarioBuscado com os dados obtidos
                        return funcionarioBuscado; 
                    }

                    // se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// cadastra um novo funcionario
        /// </summary>
        /// <param name="novoFuncionario"> objeto novoFuncionario com as informações que serão cadastradas</param>
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            // declara a conexão con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a query que será executada
                string queryInsert = "insert into Funcionarios values (@nomeFuncio, @sobrenomeFuncio, @dataNasci)";

                // declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@nomeFuncio", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenomeFuncio", novoFuncionario.sobrenome);
                    cmd.Parameters.AddWithValue("@dataNasci", novoFuncionario.dataNasci);

                    // abre a conexão com o banco
                    con.Open();

                    // executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// deleta um funcionario através do seu id 
        /// </summary>
        /// <param name="id"> id do funcionario que será deletado</param>
        public void Deletar(int id)
        {
            // declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara q query a ser executada passando o parâmetro
                string queryDelete = "delete from Funcionarios where idFuncionario = @ID";

                // declara a SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // abre a conexão com o banco
                    con.Open();

                    // executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// lista todos os funcionarios 
        /// </summary>
        /// <returns> uma lista</returns>
        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> listaFuncionario = new List<FuncionarioDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a instrução a ser executada
                string querySelectAll = "Select idFuncionario, nomeFuncio, sobrenomeFuncio, dataNasci from Funcionarios";

                // abre a conexão com o banco de dados
                con.Open();

                // declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            // Atribui à propriedade idFuncionario o valor da primeira coluna da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString(),

                            // Atribui à propriedade sobrenome o valor da terceira coluna da tabela do banco de dados
                            sobrenome = rdr[2].ToString(),

                            // Atribui à propriedade dataNasci o valor da quarta coluna da tabela do banco de dados
                            dataNasci = Convert.ToDateTime(rdr[3])
                        };

                        // adiciona o objeto funcionario  criado á listaFuncionario
                        listaFuncionario.Add(funcionario);
                    }
                }
            }

            // retorna a lista de funcionario
            return listaFuncionario;
        }
    }
}
