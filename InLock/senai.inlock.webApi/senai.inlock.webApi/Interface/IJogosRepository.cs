using senai.inlock.webApi_.Domain;
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
        List<JogosDomain> ListarTodos();

        /// <summary>
        /// busca um jogo através do seu id 
        /// </summary>
        /// <param name="id"> id do jogo que será buscado</param>
        /// <returns> um objeto jogo que foi buscado</returns>
        JogosDomain BuscarPorId(int id);
        /// <summary>
        /// atualiza um jojo existente passando o id pela url da requisição 
        /// </summary>
        /// <param name="id"> id do jogo que será atualizado</param>
        /// <param name="jogoAtualizado"> objeto genero que com as novas informações</param>
        void AtualizarIdUrl(int id, JogosDomain jogoAtualizado);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoJogo"></param>
        void Cadastrar(JogosDomain novoJogo);

        /// <summary>
        /// deleta um jogo existente
        /// </summary>
        /// <param name="id"> id do gênero que será deletado</param>
        void Deletar(int id);

        List<JogosDomain> ListarPorJogos(int id);
    }
}
