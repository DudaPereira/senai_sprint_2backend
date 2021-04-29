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
    //ex: http://localhost:5000/api/classes
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// objeto _classeRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// lista todas as classes
        /// </summary>
        /// <returns> uma lista</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // retorna a resposta da requsição fazendo a chamada para o método
            return Ok(_classeRepository.ListarTodos());
        }

        /// <summary>
        /// busca uma classe através do seu id
        /// </summary>
        /// <param name="id"> id da classe que será buscada</param>
        /// <returns> uma classe e um status Code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_classeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// cadastra uma nova classe 
        /// </summary>
        /// <param name="novaClasse"> objeto novaClasse que será cadastrada</param>
        /// <returns> um status code 201-Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            // faz a chamada para o método
            _classeRepository.Cadastrar(novaClasse);
            // retorna um status code 201
            return StatusCode(201);
        }

        /// <summary>
        /// atualiza uma classe existente 
        /// </summary>
        /// <param name="id"> id da classe que será atualizada</param>
        /// <param name="classeAtualizada"> objeto classeAtualizada com as novas informações</param>
        /// <returns> um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classeAtualizada)
        {
            // faz a chamada para o método
            _classeRepository.Atualizar(id, classeAtualizada);
            // retorna um status code 204
            return StatusCode(204);
        }

        /// <summary>
        /// deleta uma classe existente 
        /// </summary>
        /// <param name="id"> id que será deletado</param>
        /// <returns> um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz chamada para o método
            _classeRepository.Deletar(id);
            // retorna um status code 204
            return StatusCode(204);
        }
    }
}
