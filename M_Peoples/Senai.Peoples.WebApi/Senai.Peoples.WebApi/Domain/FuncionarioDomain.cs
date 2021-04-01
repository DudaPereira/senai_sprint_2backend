using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domain
{
    public class FuncionarioDomain
    {
        public int idFuncionario { get; set; }
        public string nome{ get; set; }
        public string sobrenome{ get; set; }
        public DateTime dataNasci { get; set; }
    }
}
