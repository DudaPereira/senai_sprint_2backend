using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// interface responsável pelo repositório UsuarioRepository 
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// valida o usuário
        /// </summary>
        /// <param name="email"> e-mail do usuário</param>
        /// <param name="senha"> senha do usuário</param>
        /// <returns> um objeto do tipo UsuarioDomain que foi buscado</returns>
       UsuarioDomain BuscarPorEmailSenha( string email, string senha);
    }
}
