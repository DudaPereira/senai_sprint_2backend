using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
    private string stringConexao = "Data Source=DESKTOP-DFS5ABT\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarPorId = "select idTipoUsuario, titulo from TipoUsuarios where idTipoUsuario = @ID";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarPorId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuarioDomain = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            titulo = rdr["titulo"].ToString()
                        };

                        return tipoUsuarioDomain;
                    }

                    else
                        return null;
                }
            }
        }

        public List<TipoUsuarioDomain> ListarTodos()
        {
            List<TipoUsuarioDomain> listaTipoUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "select idTipoUsuario, titulo from TipoUsuarios";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            titulo = rdr["titulo"].ToString()
                        };

                        listaTipoUsuario.Add(tipoUsuario);
                    }
                }
            }

            return listaTipoUsuario;
        }
    }
}
