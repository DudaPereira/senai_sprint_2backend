using senai_gufi_webApi.Contexts;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Repository
{
    public class TiposEventosRepository : ITiposEventoRepository
    {
        /// <summary>
        /// objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id"> id do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado"> objeto com as novas informações</param>
        public void Atualizar(int id, TiposEvento tiposEventoAtualizado)
        {
            // busca um tipo de evento através do id
            TiposEvento tipoEventoBuscado = BuscarPorId(id);

            // verifica se o título do tipo de evento foi informado
            if (tiposEventoAtualizado.TituloTipoEvento != null)
            {
                // atribui os novos valores aos campos existentes
                tipoEventoBuscado.TituloTipoEvento = tiposEventoAtualizado.TituloTipoEvento;
            }

            // atualiza o tipo de evento que foi buscado
            ctx.TiposEventos.Update(tipoEventoBuscado);

            // salva as informações para serevem gravas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// busca um tipo de evento através do ID
        /// </summary>
        /// <param name="id"> id do tipo de evento que será buscado</param>
        /// <returns> um tipo de evento encontrado</returns>
        public TiposEvento BuscarPorId(int id)
        {
            // retorna o primeiro tipo de evento para o ID informado
            return ctx.TiposEventos.FirstOrDefault(te => te.IdTipoEvento == id);
        }

        /// <summary>
        /// cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento"> objeto com as informações que serão cadastradas</param>
        public void Cadastrar(TiposEvento novoTipoEvento)
        {
            // adiciona este novoTipoEvento
            ctx.TiposEventos.Add(novoTipoEvento);

            // salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// deleta um tipo de evento existente
        /// </summary>
        /// <param name="id"> id do tipo de evento que será deletado</param>
        public void Deletar(int id)
        {
            // remove o tipo de evento que foi buscado
            ctx.TiposEventos.Remove(BuscarPorId(id));

            // salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// lista todos os tipos de eventos
        /// </summary>
        /// <returns> uma lista de tipos de eventos</returns>
        public List<TiposEvento> ListarTodos()
        {
            // retorna uma lista com todas as informações dos tipos de eventos
            return ctx.TiposEventos.ToList();
        }
    }
}
