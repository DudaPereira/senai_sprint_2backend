using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domain
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
