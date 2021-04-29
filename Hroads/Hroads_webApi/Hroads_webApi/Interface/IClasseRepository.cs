using Hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_webApi.Interface
{
    interface IClasseRepository
    {
        /// <summary>
        /// lista todas as classes
        /// </summary>
        /// <returns> retorna uma lista</returns>
        List<Classe> ListarTodos();

        /// <summary>
        /// busca uma classe através do seu id
        /// </summary>
        /// <param name="id"> id da classe que será buscada </param>
        /// <returns> uma classe buscada</returns>
        Classe BuscarPorId(int id);

        /// <summary>
        /// cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse"> objeto chamado novaClasse que será cadastrada</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// atualiza uma classe existente
        /// </summary>
        /// <param name="id"> id da classe que será atualizada</param>
        /// <param name="classeAtualizada"> objeto classeAtualizada com as novas informações</param>
        void Atualizar(int id, Classe classeAtualizada);

        /// <summary>
        /// deleta uma classe existente 
        /// </summary>
        /// <param name="id"> id da classe que será deletada</param>
        void Deletar(int id);
    }
}
