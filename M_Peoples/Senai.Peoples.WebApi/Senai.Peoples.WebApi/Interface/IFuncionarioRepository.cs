using Senai.Peoples.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interface
{
    /// <summary>
    /// interface responsável pelo repositório FuncionarioRepository
    /// </summary>
    interface IFuncionarioRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);

        /// <summary>
        /// lista todos os funcionarios
        /// </summary>
        /// <returns></returns>
        List<FuncionarioDomain> ListarTodos();

        /// <summary>
        /// busca um funcionario atráves do seu id
        /// </summary>
        /// <param name="id"> id do funcionario que será buscado</param>
        /// <returns> um objeto gênero que foi buscado</returns>
        FuncionarioDomain BuscaPorId(int id);

        /// <summary>
        /// cadastra um novo funcionario
        /// </summary>
        /// <param name="novoFuncionario"></param>
        void Cadastrar(FuncionarioDomain novoFuncionario);

        /// <summary>
        /// atualiza um funcionario passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id"> id do funcionario que será atualizado</param>
        /// <param name="funcionario"> objeto funcionario com as novas informações</param>
        void AtualizarIdUrl(int id, FuncionarioDomain funcionario);

        /// <summary>
        /// Deleta um funcionario existente
        /// </summary>
        /// <param name="id">id do funcionario que será deletado</param>
        void Deletar(int id);
    }
}
