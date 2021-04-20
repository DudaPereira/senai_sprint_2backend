using senai.inlock.webApi_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interface
{
    interface IEstudioRepository
    {
        List<EstudioDomain> List();
        EstudioDomain BuscarPorId(int id);
        void Atualizar(int id, EstudioDomain estudioAtualizado);
        void Cadastrar(EstudioDomain novoEstudio);
        void Deletar(int id);
    }
}
