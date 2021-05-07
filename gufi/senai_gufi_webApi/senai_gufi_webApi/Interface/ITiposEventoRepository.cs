using senai_gufi_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Interface
{
    /// <summary>
    /// classe responsável pelo repositório TiposEventoRepository
    /// </summary>
    interface ITiposEventoRepository
    {
        // estrutura de um método
        // tipoRetorno NomeMetodo(TipoParametro NomeParametro);

        /// <summary>
        /// lista todos os tipos de eventos
        /// </summary>
        /// <returns> uma lista do tipo evento</returns>
        List<TiposEvento> ListarTodos();

        /// <summary>
        /// busca um tipo de evento através do seu id
        /// </summary>
        /// <param name="id"> id do tipo de evento que será buscado</param>
        /// <returns> um tipo de evento encontrado</returns>
        TiposEvento BuscarPorId(int id);

        /// <summary>
        /// cadastra um novo tipo de evento 
        /// </summary>
        /// <param name="novoTipoEvento"> objeto com as informações que serão cadastradas</param>
        void Cadastrar(TiposEvento novoTipoEvento);

        /// <summary>
        /// atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id"> id do tipo de evento que será atualizado</param>
        /// <param name="tiposEventoAtualizado"> objeto com as novas informações</param>
        void Atualizar(int id, TiposEvento tiposEventoAtualizado);

        /// <summary>
        /// deleta um tipo de evento existente
        /// </summary>
        /// <param name="id"> id do tipo de evento que será deletado</param>
        void Deletar(int id);
    }
}
