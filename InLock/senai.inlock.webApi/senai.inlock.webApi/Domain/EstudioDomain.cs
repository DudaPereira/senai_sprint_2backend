using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domain
{
    public class EstudioDomain
    {
        [Required(ErrorMessage = "Nome do estúdio obrigatório!!")]
        public int idEstudio { get; set; }
        public string nomeEstudio { get; set; }
        public JogosDomain jogos { get; set; }
    }

}
