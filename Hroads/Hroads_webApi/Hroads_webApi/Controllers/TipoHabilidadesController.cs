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
    //ex: http://localhost:5000/api/tipoHabilidades
    [Route("api/[controller]")]
    // define que é um controlador de API
    [ApiController]
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        public TipoHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoHabilidadeRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoHabilidadeRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipoHabilidade)
        {
            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade tipoHabilidadeAtualizado)
        {
            _tipoHabilidadeRepository.Atualizar(id, tipoHabilidadeAtualizado);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoHabilidadeRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
