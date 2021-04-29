using Hroads_webApi.Contexts;
using Hroads_webApi.Domains;
using Hroads_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_webApi.Repository
{
    public class ClasseRepository : IClasseRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        hroadsContext ctx = new hroadsContext();

        public void Atualizar(int id, Classe classeAtualizada)
        {
            // busca uma classe através do id
            Classe classeBuscado = ctx.Classes.Find(id);
            // verifica se o nome da classe foi informado
            if (classeAtualizada.NomeClasse != null)
            {
                // atribui os novos valores aos campos existentes
                classeBuscado.NomeClasse = classeAtualizada.NomeClasse;
            }

            // atualiza o estúdio que foi buscado
            ctx.Classes.Update(classeBuscado);
            // salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Classe BuscarPorId(int id)
        {
            // retorna a primeira classe encontrada pera o id informado
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(Classe novaClasse)
        {
            // adiciona esta novaClasse
            ctx.Classes.Add(novaClasse);
            // salva as informações para serem gravadas no banco de dados 
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca uma classe através do seu id
            Classe classeBuscada = ctx.Classes.Find(id);
            // remove a classe que foi buscada 
            ctx.Classes.Remove(classeBuscada);
            // salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Classe> ListarTodos()
        {
            // retorna uma lista em ordem alfabetica 
            return ctx.Classes.OrderBy(c => c.NomeClasse).ToList(); ;
        }
    }
}
