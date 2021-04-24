using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-DFS5ABT\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";

        public void AtualizarIdUrl(int id, JogosDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdUrl = "update Jogos set Jogos.idEstudio = @idEstudio, Jogos.nomeJogo = @nomeJogo, Jogos.descricao = @descricao, Jogos.dataLancamento = @dataLancamento, Jogos.valor = @valor where idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@idEstudio", jogoAtualizado.idEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarPorId = "select idJogo, nomeJogo, descricao, dataLancamento, valor from Jogos where Jogos.idJogo = @ID";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarPorId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain jogosBuscado = new JogosDomain
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            valor = Convert.ToDouble(rdr["valor"])
                        };

                        return jogosBuscado;
                    }

                    return null; 
                }
            }
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "insert into Jogos(idEstudio, nomeJogo, descricao, dataLancamento, valor) values (@idEstudio, @nome, @descricao, @dataLancamento, @valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);
                    cmd.Parameters.AddWithValue("@nome", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("valor", novoJogo.valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "delete Jogos where Jogos.idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarPorJogos(int id)
        {
            List<JogosDomain> listaPorJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectJogos = "select idJogo, nomeJogo, descricao, dataLancamento, valor, Jogos.idEstudio, Estudios.IdEstudio, nomeEstudio from Jogos Inner Join Estudios on Jogos.idEstudio = Estudios.idEstudio where Jogos.idEstudio = @ID";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectJogos, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogos = new JogosDomain
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            valor = Convert.ToDouble(rdr["valor"]), 

                            estudio = new EstudioDomain
                            {
                                idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            }
                        };

                        listaPorJogos.Add(jogos);
                    }
                }
            }

            return listaPorJogos;
        }

        public List<JogosDomain> ListarTodos()
        {
            List<JogosDomain> listaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "Select idJogo, idEstudio, nomeJogo, descricao, dataLancamento, valor from Jogos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            idEstudio = Convert.ToInt32(rdr[1]),
                            nomeJogo = rdr[2].ToString(), 
                            descricao = rdr[3].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[4]),
                            valor = Convert.ToDouble(rdr[5])

                        };

                        listaJogos.Add(jogo);
                    }
                }
            }

            return listaJogos;
        }
    }
}
