using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domain
{
    public class JogosDomain
    {
        public int idJogo { get; set; }
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "Nome do jogo obrigatório!!")]
        public string nomeJogo { get; set; }
        public string descricao { get; set; }

        [Required(ErrorMessage = "Data de lançamento do jogo obrigatório!!")]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "Valor do jogo obrigatório!!")]
        public double valor { get; set; }

        public EstudioDomain estudio { get; set; }
    }
}
