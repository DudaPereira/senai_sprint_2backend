using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints referentes aos gêneros
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        // <summary>
        /// Instancia o objeto _generoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code</returns>
        /// http://localhost:5000/api/generos
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(listaGeneros);
        }

        /// <summary>
        /// busca um gênero através do seu id
        /// </summary>
        /// <param name="id"> id do gênero que será buscado</param>
        /// <returns> um gênero buscado ou NotFound caso nenhum gênero seja encontrado</returns>
        /// http://localhost:5000/api/generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cria um objeto generoByscado que irá receber o gênero buscado no bamco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // verifica se nenhum gênero foi encontrado 
            if (generoBuscado == null)
            {
                // caso não seja encontrado, retorna um status code 204 - Not Found com a mensagem personalizada
                return NotFound("Nenhum gênero foi encontrado!!");
            }

            // caso seja encontrado, retorna um status code 200 - Ok
            return Ok(generoBuscado);
        }

        /// <summary>
        /// cadastra um novo gênero
        /// </summary>
        /// <returns> um status code 201 - Created</returns>
        /// http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // faz a chamada para o método .Cadastrar()
            _generoRepository.Cadastrar(novoGenero);

            // retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// 
        /// </summary>atualiza o gênero existente passando o seu id pela url da requisição
        /// <param name="id"> id do gênero que será atualizado</param>
        /// <param name="generoAtualizado"> objeto generoAtualizado com as novas informações</param>
        /// <returns> um status code</returns>
        /// http://localhost:5000/api/generos/3
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            // cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // caso não seja encontrado, retorna NotFound co uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (generoBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Genero não encontrado!!",
                            erro = true
                        }
                    );
            }

            // tenta atualizar o registro 
            try
            {
                // faz a chamada para o método .AtualizarIdUrl()
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                // retorna um status code 204 - No content
                return NoContent();
            }
            // caso ocorra algum erro
            catch (Exception codErro)
            {
                // retorna um status code 400 - BadRequest e o codigo do erro
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            // Verifica se algum gênero foi encontrado
            if (generoBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo()
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception codErro)
                {
                    // Retorna BadRequest com o código do erro
                    return BadRequest(codErro);
                }
            }

            // Caso não seja encontrado, retorna NotFoun com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Gênero não encontrado!"
                    }
                );
        }

        /// <summary>
        /// deleta um gênero existente
        /// </summary>
        /// <param name="id"> id do gênero que será deletado</param>
        /// <returns> status code 204 - No Content</returns>
        /// http://localhost:5000/api/generos/6
        [HttpDelete("{id}")] 

        public IActionResult Delete(int id)
        {
            // faz a chamada para o meétodo .Deletar()
            _generoRepository.Deletar(id);

            // retorna um status code 204 - No content
            return StatusCode(204);
       
        }
    }
}
