using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interface;
using senai_gufi_webApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Controllers
{
    // define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]
    // define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/tiposeventos
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class TiposEventosController : ControllerBase
    {
        /// <summary>
        /// objeto que irá receber os métodos definidos na interface ITiposEventoRepository
        /// </summary>
        private ITiposEventoRepository _tiposEventoRepository { get; set; }

        /// <summary>
        /// instancia o objeto _tiposEventoRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public TiposEventosController()
        {
            _tiposEventoRepository = new TiposEventosRepository();
        }

        /// <summary>
        /// lista todos os tipos de eventos
        /// </summary>
        /// <returns> uma lista de tipos de eventos e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposEventoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                // retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// busca um tipo de evento através do id
        /// </summary>
        /// <param name="id"> id do tipo de evento que será buscado</param>
        /// <returns> um tipo de evento buscadoe um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposEventoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                // retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento"> objeto que será cadastrado</param>
        /// <returns> um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TiposEvento novoTipoEvento)
        {
            try
            {
                // faz a chamada para o método
                _tiposEventoRepository.Cadastrar(novoTipoEvento);

                // retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                // Retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id"> id do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado"> objeto com as novas informações</param>
        /// <returns> um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposEvento tipoEventoAtualizado)
        {
            try
            {
                // faz a chamada para o método
                _tiposEventoRepository.Atualizar(id, tipoEventoAtualizado);

                // retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// deleta um tipo de evento existente
        /// </summary>
        /// <param name="id"> id do tipo de evento que será deletado</param>
        /// <returns> um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // faz a chamada para o método
                _tiposEventoRepository.Deletar(id);

                // retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }
    }
}
