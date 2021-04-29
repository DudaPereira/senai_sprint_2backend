using Hroads_webApi.Domains;
using Hroads_webApi.Interface;
using Hroads_webApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_webApi.Controllers
{
    // define que o tipo de resposta da API será formato json
    [Produces("application/json")]
    // define que a rota de uma requisição será no formato dominio/api/nomeController
    //ex: http://localhost:5000/api/habilidades
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// objeto _habilidadeRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// lista todas as habilidades
        /// </summary>
        /// <returns> uma lista</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // retorna a resposta da requsição fazendo a chamada para o método
            return Ok(_habilidadeRepository.ListarTodos());
        }

        /// <summary>
        /// busca uma habilidade através do seu id
        /// </summary>
        /// <param name="id"> id da habilidade que será buscada</param>
        /// <returns> uma classe e um status Code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade"> objeto novaHabilidade que será cadastrada</param>
        /// <returns> um status code 201-Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            // faz a chamada para o método
            _habilidadeRepository.Cadastrar(novaHabilidade);
            // retorna um status code 201
            return StatusCode(201);
        }

        /// <summary>
        /// atualiza uma habilidade existente 
        /// </summary>
        /// <param name="id"> id da habilidade que será atualizada</param>
        /// <param name="classeAtualizada"> objeto habilidadeAtualizada com as novas informações</param>
        /// <returns> um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade HabilidadeAtualizada)
        {
            // faz a chamada para o método
            _habilidadeRepository.Atualizar(id, HabilidadeAtualizada);
            // retorna um status code 204
            return StatusCode(204);
        }

        /// <summary>
        /// deleta uma habilidade existente 
        /// </summary>
        /// <param name="id"> id que será deletado</param>
        /// <returns> um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz chamada para o método
            _habilidadeRepository.Deletar(id);
            // retorna um status code 204
            return StatusCode(204);
        }

        /// <summary>
        /// Lista todos os estúdios com seus respectivos jogos
        /// </summary>
        /// <returns>Uma lista de estúdios com os jogos e um status code 200 - Ok</returns>
        [HttpGet("idTipoHabilidade")]
        public IActionResult GetHabilidade()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.ListarHabilidade());
        }
    }
}
