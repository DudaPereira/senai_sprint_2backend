using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domain
{
    public class FuncionarioDomain
    {
        public int idFuncionario { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório!")]
        public string nome{ get; set; }
        public string sobrenome{ get; set; }

        [Required(ErrorMessage ="Informe a data de nascimento do funcionário")]
        [DataType(DataType.Date)]
        public DateTime dataNasci { get; set; }
    }
}
