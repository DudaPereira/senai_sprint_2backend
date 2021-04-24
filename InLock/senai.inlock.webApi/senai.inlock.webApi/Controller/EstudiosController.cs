using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controller
{
    // define que o tipo de resposta da API será formato json
    [Produces("application/json")]

    // define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]

    // define que é um controlador de API
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// objeto _estudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepositiry();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// http://localhost:5000/api/estudios
        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();
            return Ok(listaEstudios);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            List<EstudioDomain> listaPorEstudio = _estudioRepository.ListarTodos();

            return Ok(listaPorEstudio);
        }

        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }

        [Authorize(Roles ="1")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudioAtualizar)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
            return NotFound
                (
                   new
                   {
                       mensagem = "Estudio não encontrado!",
                       erro = true 
                   }
                );

            }

           try
              {
                _estudioRepository.Atualizar(id, estudioAtualizar);
                return NoContent();
              }
              catch (Exception codErro)
              {
                return BadRequest(codErro);
              }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estudio foi encontrado!");
            }

            return Ok(estudioBuscado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estudioRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
