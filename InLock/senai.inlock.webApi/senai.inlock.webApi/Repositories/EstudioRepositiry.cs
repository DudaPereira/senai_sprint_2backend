using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepositiry : IEstudioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-DFS5ABT\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estudioAtualizado"></param>
        public void Atualizar(int id, EstudioDomain estudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdUrl = "Update Estudios set nomeEstudio = @Nome where idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", estudioAtualizado.nomeEstudio);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "Select idEstudio, nomeEstudio from Estudios where idEstudio = @ID";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain estudioDomain = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };

                        return estudioDomain;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoEstudio"></param>
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "insert into Estudios(nomeEstudio) values (@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.nomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "Delete from Estudios where idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarPorEstudio(int id)
        {
            List<EstudioDomain> listarPorEstudio = new List<EstudioDomain>();

            using (SqlConnection con =  new SqlConnection(stringConexao))
            {
                string querySelectPorEstudio = "select Estudios.nomeEstudio, nomeJogo from Estudios left join Jogos on Estudios.idEstudio = Jogos.idEstudiog where Estudios.idJogos = @ID"; 

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectPorEstudio, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            nomeEstudio = rdr["nomeEstudio"].ToString(),
                            jogos = new JogosDomain
                            {
                                idJogo = Convert.ToInt32(rdr["idJogo"]),
                                nomeJogo = rdr["nomeJogo"].ToString(),

                            }
                        };

                        listarPorEstudio.Add(estudio);
                    }
                }
            }

            return listarPorEstudio;
        }

        /// <summary>
        /// lista todos os estudios 
        /// </summary>
        /// <returns> uma lista de estudios</returns>
        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "Select idEstudio, nomeEstudio from Estudios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nomeEstudio = rdr[1].ToString()
                        };

                        listaEstudio.Add(estudio);
                    }
                }
            }

            return listaEstudio;
        }
    }
}
