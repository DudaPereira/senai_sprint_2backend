using Hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_webApi.Interface
{
    interface ITipoHabilidadeRepository
    {
        List<TipoHabilidade> ListarTodos();
        TipoHabilidade BuscarPorId(int id);
        void Cadastrar(TipoHabilidade novaTipoHabilidade);
        void Atualizar(int id, TipoHabilidade tipoHabilidadeAtualizada);
        void Deletar(int id);
    }
}
