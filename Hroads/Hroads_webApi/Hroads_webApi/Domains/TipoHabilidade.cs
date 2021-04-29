using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hroads_webApi.Domains
{
    public partial class TipoHabilidade
    {
        public TipoHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipoHabilidade { get; set; }

        [Required(ErrorMessage = "Nome tipo habilidade obrigatório!!")]
        public string NomeTipoHabilidade { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
