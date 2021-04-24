using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-DFS5ABT\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";

        public UsuarioDomain Login(string email, string senha)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

            string querySelect = "select * from Usuario where email = @email and senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString()
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
