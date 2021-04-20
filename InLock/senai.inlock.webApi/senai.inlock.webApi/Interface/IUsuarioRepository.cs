using senai.inlock.webApi_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interface
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// verifica se login e senha estao corretos
        /// </summary>
        /// <param name="email"> email do usuario</param>
        /// <param name="senha"> senha do usuario</param>
        /// <returns>UsuarioDomain</returns>
        UsuarioDomain Login(string email, string senha);
    }
}
