using Hroads_webApi.Contexts;
using Hroads_webApi.Domains;
using Hroads_webApi.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_webApi.Repository
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        hroadsContext ctx = new hroadsContext();

        public void Atualizar(int id, Habilidade HabilidadeAtualizada)
        {
            // busca uma classe através do id
            Habilidade habilidadeBuscado = ctx.Habilidades.Find(id);
            // verifica se o nome da classe foi informado
            if (HabilidadeAtualizada.NomeHabilidade != null)
            {
                // atribui os novos valores aos campos existentes
                habilidadeBuscado.NomeHabilidade = HabilidadeAtualizada.NomeHabilidade;
            }

            // atualiza o estúdio que foi buscado
            ctx.Habilidades.Update(habilidadeBuscado);
            // salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            // retorna a primeira habilidade encontrada pera o id informado
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);

        }
        public void Cadastrar(Habilidade novaHabilidade)
        {
            // adiciona esta novaHabilidade
            ctx.Habilidades.Add(novaHabilidade);
            // salva as informações para serem gravadas no banco de dados 
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca uma classe através do seu id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);
            // remove a classe que foi buscada 
            ctx.Habilidades.Remove(habilidadeBuscada);
            // salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Habilidade> ListarHabilidade()
        {
            //Retorna uma lista de habilidades com seus respectivos tipos
            return ctx.Habilidades.Include(h => h.IdTipoHabilidadeNavigation).ToList();
        }

        public List<Habilidade> ListarTodos()
        {
            // retorna uma lista com todas as informações das classes
            return ctx.Habilidades.ToList();
        }
    }
}
