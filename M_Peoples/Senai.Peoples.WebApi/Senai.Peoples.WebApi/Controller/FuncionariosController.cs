using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interface;
using Senai.Peoples.WebApi.Repositorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// controller responsável pelos endpoints referentes aos funcionarios
/// </summary>
namespace Senai.Peoples.WebApi.Controller
{
    // define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    // define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/funcionarios
    [Route("api/[controller]")]

    // define que é um controlador de API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// objeto _funcionarioRepository que irá receber todos os métodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _Funcionarioepository para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de funcionario e um status code</returns>
        /// http://localhost:5000/api/funcionarios
        [HttpGet]
        public IActionResult Get()
        {
            // cria uma lista nomeada listaFuncionario para receber os dados
            List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.ListarTodos();

            // retorna o status code 200 (Ok) com a lista de funcionario no formato JSON
            return Ok(listaFuncionarios);
        }

        /// <summary>
        /// busca um funcionario através do seu id
        /// </summary>
        /// <param name="id"> id do funcionario que será buscado</param>
        /// <returns> um funcionario buscado ou NotFound caso nenhum seja encontrado</returns>
        /// http://localhost:5000/api/funcionarios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscaPorId(id);

            if (funcionarioBuscado == null)
            {
                // caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum funcionario foi encontrado!!");
            }

            // caso seja encontrado, retorna o funcionario buscado com um status code 200 - Ok
            return Ok(funcionarioBuscado);
        }

        /// <summary>
        /// cadastra um novo funcionario
        /// </summary>
        /// <returns> um status code 201 - Created</returns>
        /// http://localhost:5000/api/funcionarios
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoGenero)
        {
            // faz a chamada para o método .Cadastrar()
            _funcionarioRepository.Cadastrar(novoGenero);

            // retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// atualiza um funcionario existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="funcionarioAtualizado"> objeto funcionarioAtualizado com as novas informações</param>
        /// <returns> um status code</returns>
        /// http://localhost:5000/api/funcionarios/2
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionarioDomain funcionarioAtualizado)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscaPorId(id);

            if (funcionarioBuscado == null)
            {
               return NotFound
                (
                   new
                   {
                       mensagem = "Funcionario não foi encontrado!!", 
                       erro = true 
                   }
                );

            }

            try
            {
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                return NoContent();
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }

        }

        /// <summary>
        /// deleta um funcionario existente
        /// </summary>
        /// <param name="id"> id de funcionario que será deletado</param>
        /// <returns> um status code 204 - No Content</returns>
        /// http://localhost:5000/api/funcionarios/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz a chamada para o metodo Deletar()
            _funcionarioRepository.Deletar(id);

            // retorna um status code 204 - No Content
            return StatusCode(204);
        }

    }
}
