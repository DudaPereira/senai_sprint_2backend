using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Domains
{
    /// <summary>
    /// classe que representa a entidade (tabela) Usuarios
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        // define que o campo é obrigatório
        [Required(ErrorMessage ="Informe o e-mail")]
        public string email { get; set; }

        // define que o campo é obrigatório, com no mínimo 3 e no máximo 20 caracteres
        [Required(ErrorMessage ="Informe a senha")]
        [StringLength(20, MinimumLength =3, ErrorMessage ="O campo precisa ter no mínimo 3 caracterer")]
        public string senha { get; set; }
        public string permissao { get; set; }
    }
}
