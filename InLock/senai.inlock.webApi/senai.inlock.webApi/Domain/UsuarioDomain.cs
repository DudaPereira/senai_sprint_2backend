using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domain
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "Email do usuário obrigatório!!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Senha do usuário obrigatório!!")]
        public string senha { get; set; }
    }
}
