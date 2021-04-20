using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domain
{
    public class JogosDomain
    {
        public int idJogo { get; set; }
        public EstudioDomain idEstudio { get; set; }
        public string nomeJogo { get; set; }
        public string descricao { get; set; }
        public DateTime dataLancamento { get; set; }
        public double valor { get; set; }
    }
}
