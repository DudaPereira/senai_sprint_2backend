using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hroads_webApi.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Personagems = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }

        [Required(ErrorMessage = "Nome da classe obrigatório!!")]
        public string NomeClasse { get; set; }

        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
