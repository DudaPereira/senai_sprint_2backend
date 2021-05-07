using senai_gufi_webApi.Contexts;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Repository
{
    /// <summary>
    /// classe responsável pelo repositório dos usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        // <summary>
        /// objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// valida o usuário
        /// </summary>
        /// <param name="email"> e-mail do usuário</param>
        /// <param name="senha"> senha do usuário</param>
        /// <returns> um objeto do tipo Usuario que foi buscado</returns>
        public Usuario Login(string email, string senha)
        {
            // retorna o usuário encontrado através do e-mail e da senha
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
