using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domain;
using senai.inlock.webApi_.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogoRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// http://localhost:5000/api/jogos
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> listaJogos = _jogoRepository.ListarTodos();
            return Ok(listaJogos);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            List<JogosDomain> listaPorJogo = _jogoRepository.ListarTodos();

            return Ok(listaPorJogo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogosDomain jogobuscado = _jogoRepository.BuscarPorId(id);

            if (jogobuscado == null)
            {
                return NotFound("Nenhum jogo foi encontrado!!");
            }

            return Ok(jogobuscado);
        }

        [Authorize(Roles ="1")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, JogosDomain jogoAtualizado)
        {
            JogosDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound
                    (
                       new
                       {
                           mensagem = "Jogo não encontrado!!",
                           erro = true
                       }
                    );
            }

            try
            {
                _jogoRepository.AtualizarIdUrl(id, jogoAtualizado);
                return NoContent();
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
        }

        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }

        [Authorize(Roles ="1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _jogoRepository.Deletar(id);
            return StatusCode(204);
        }

    }
}
