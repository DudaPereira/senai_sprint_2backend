using senai_gufi_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Interface
{
    interface IPresencaRepository
    {
        /// <summary>
        /// lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id"> id do usuário que participa dos eventos listados</param>
        /// <returns> uma lista de presenças com os dados dos eventos</returns>
        List<Presenca> ListarMinhas(int id);

        /// <summary>
        /// cria uma nova presença
        /// </summary>
        /// <param name="inscricao"> objeto com as informações da inscrição</param>
        void Inscrever(Presenca inscricao);

        /// <summary>
        /// altera o status de uma presença
        /// </summary>
        /// <param name="id"> id da presença que terá sua situação alterada</param>
        /// <param name="status"> parâmetro que atualiza a situação da presença para 0 - Recusada, 1 - Confirmada, 2 - Não confirmada</param>
        void AprovarRecusar(int id, string status);
    }
}
