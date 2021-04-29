using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hroads_webApi.Domains
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }

        [Required(ErrorMessage = "Nome da habilidade obrigatório!!")]
        public string NomeHabilidade { get; set; }
        public int? IdTipoHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabilidadeNavigation { get; set; }
    }
}
