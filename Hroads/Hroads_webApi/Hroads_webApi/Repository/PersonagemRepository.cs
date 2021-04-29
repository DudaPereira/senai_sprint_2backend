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
    public class PersonagemRepository : IPersonagemRepository
    {
        // objeto contexto por onde serão chamados os métodos do EF Core
        hroadsContext ctx = new hroadsContext();

        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            // busca uma classe através do id
            Personagem personagemBuscado = ctx.Personagems.Find(id);
            // verifica se o nome da classe foi informado
            if (personagemAtualizado.NomePersonagem != null)
            {
                // atribui os novos valores aos campos existentes
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
            }

            // atualiza o estúdio que foi buscado
            ctx.Personagems.Update(personagemBuscado);
            // salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
            // retorna o primeiro personagem encontrado pera o id informado
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            // adiciona esta novoPersonagem
            ctx.Personagems.Add(novoPersonagem);
            // salva as informações para serem gravadas no banco de dados 
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca um personagem através do seu id
            Personagem personagemBuscada = ctx.Personagems.Find(id);
            // remove o personagem que foi buscada 
            ctx.Personagems.Remove(personagemBuscada);
            // salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Personagem> ListaOrdenada()
        {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).OrderBy(p => p.IdClasseNavigation.NomeClasse).ToList();
        }

        public List<Personagem> ListarTodos()
        {
            // retorna uma lista com todas as informações das classes
            return ctx.Personagems.ToList();
        }
    }
}
