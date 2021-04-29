using Hroads_webApi.Contexts;
using Hroads_webApi.Domains;
using Hroads_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_webApi.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        hroadsContext ctx = new hroadsContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado.Permissao != null)
            {
                TipoUsuarioBuscado.Permissao = tipoUsuarioAtualizado.Permissao;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id); ;
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);
            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            // retorna uma lista com todas as informações das classes
            return ctx.TipoUsuarios.ToList();
        }
    }
}
