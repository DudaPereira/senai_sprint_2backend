using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hroads_webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }

        [Required(ErrorMessage = "Nome do personagem obrigatório!!")]
        public string NomePersonagem { get; set; }

        [Required(ErrorMessage = "Capacidade Maxima de Vida obrigatório!!")]
        public int CapacidadeMaximaVida { get; set; }

        [Required(ErrorMessage = "Capacidade Maxima Mana obrigatório!!")]
        public int CapacidadeMaximaMana { get; set; }

        [Required(ErrorMessage = "Data de Atualização obrigatório!!")]
        public DateTime DataAtualização { get; set; }

        [Required(ErrorMessage = "Data de Criação obrigatório!!")]
        public DateTime DataDeCriacao { get; set; }
        public int? IdClasse { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
