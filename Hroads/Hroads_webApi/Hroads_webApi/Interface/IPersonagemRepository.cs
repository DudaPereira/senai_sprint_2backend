using Hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_webApi.Interface
{
    interface IPersonagemRepository
    {
        List<Personagem> ListaOrdenada();
        List<Personagem> ListarTodos();
        Personagem BuscarPorId(int id);
        void Cadastrar(Personagem novoPersonagem);
        void Atualizar(int id, Personagem personagemAtualizado);
        void Deletar(int id);
    }
}
