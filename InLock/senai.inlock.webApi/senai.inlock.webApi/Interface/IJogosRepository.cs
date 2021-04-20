using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interface
{
    interface IJogosRepository
    {
        /// <summary>
        /// lista todos os jogos
        /// </summary>
        /// <returns> uma lista jogos</returns>
        List<JogoDomain> List();

        /// <summary>
        /// busca um jogo através do seu id 
        /// </summary>
        /// <param name="id"> id do jogo que será buscado</param>
        /// <returns> um objeto jogo que foi buscado</returns>
        JogoDomain BuscarPorId(int id);
        /// <summary>
        /// atualiza um jojo existente passando o id pela url da requisição 
        /// </summary>
        /// <param name="id"> id do jogo que será atualizado</param>
        /// <param name="jogoAtualizado"> objeto genero que com as novas informações</param>
        void AtualizarIdUrl(int id, JogoDomain jogoAtualizado);

        /// <summary>
        /// cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo"> objeto novoJogo com as informações que serão cadastradas</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// deleta um jogo existente
        /// </summary>
        /// <param name="id"> id do gênero que será deletado</param>
        void Deletar(int id);
    }
}
