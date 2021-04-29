using Hroads_webApi.Contexts;
using Hroads_webApi.Domains;
using Hroads_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_webApi.Repository
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        hroadsContext ctx = new hroadsContext();

        public void Atualizar(int id, TipoHabilidade tipoHabilidadeAtualizada)
        {
            TipoHabilidade tipoHabilidadeBuscado = ctx.TipoHabilidades.Find(id);

            if (tipoHabilidadeAtualizada.NomeTipoHabilidade != null)
            {
                tipoHabilidadeBuscado.NomeTipoHabilidade = tipoHabilidadeAtualizada.NomeTipoHabilidade;
            }

            ctx.TipoHabilidades.Update(tipoHabilidadeBuscado);
            ctx.SaveChanges();
        }

        public TipoHabilidade BuscarPorId(int id)
        {
            return ctx.TipoHabilidades.FirstOrDefault(t => t.IdTipoHabilidade == id);
        }

        public void Cadastrar(TipoHabilidade novaTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(novaTipoHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoHabilidade TipoHabilidadeBuscada = ctx.TipoHabilidades.Find(id);
            ctx.TipoHabilidades.Remove(TipoHabilidadeBuscada);
            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarTodos()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
