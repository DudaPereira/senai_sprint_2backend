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
    //ex: http://localhost:5000/api/personagens
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        /// <summary>
        /// objeto _personagemRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// lista todas os personagem
        /// </summary>
        /// <returns> uma lista</returns>
       [Authorize(Roles ="1,2")]
        [HttpGet]
        public IActionResult Get()
        {
            // retorna a resposta da requsição fazendo a chamada para o método
            return Ok(_personagemRepository.ListarTodos());
        }

        [HttpGet("Ordenar")]
        public IActionResult GetOrdenar()
        {
            return Ok(_personagemRepository.ListaOrdenada());
        }

        /// <summary>
        /// busca um personagem através do seu id
        /// </summary>
        /// <param name="id"> id do personagem que será buscada</param>
        /// <returns> um personagem e um status Code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_personagemRepository.BuscarPorId(id));
        }


        /// <summary>
        /// cadastra um novo personagem 
        /// </summary>
        /// <param name="novoPersonagem"> objeto novoPersonagem que será cadastrada</param>
        /// <returns> um status code 201-Created</returns>
        [Authorize(Roles ="2")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            // faz a chamada para o método
            _personagemRepository.Cadastrar(novoPersonagem);
            // retorna um status code 201
            return StatusCode(201);
        }

        /// <summary>
        /// atualiza um personagem existente 
        /// </summary>
        /// <param name="id"> id do personagem que será atualizada</param>
        /// <param name="classeAtualizada"> objeto personagemAtualizada com as novas informações</param>
        /// <returns> um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem personagemAtualizada)
        {
            // faz a chamada para o método
            _personagemRepository.Atualizar(id, personagemAtualizada);
            // retorna um status code 204
            return StatusCode(204);
        }

        /// <summary>
        /// deleta um personagem existente 
        /// </summary>
        /// <param name="id"> id que será deletado</param>
        /// <returns> um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz chamada para o método
            _personagemRepository.Deletar(id);
            // retorna um status code 204
            return StatusCode(204);
        }
    }
}
