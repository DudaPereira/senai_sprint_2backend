using Hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_webApi.Interface
{
    interface IHabilidadeRepository
    {
        List<Habilidade> ListarTodos();
       Habilidade BuscarPorId(int id);
        void Cadastrar(Habilidade novaHabilidade);
        void Atualizar(int id, Habilidade HabilidadeAtualizada);
        void Deletar(int id);

        /// <summary>
        /// lista todos as habilidades com suass respectivas TipoHabilidade
        /// </summary>
        /// <returns></returns>
        List<Habilidade> ListarHabilidade();
    }
}
