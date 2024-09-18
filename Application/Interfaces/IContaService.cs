using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IContaService
    {
        Task<ResultResponse> AdicionarConta(CriarContaRequest conta);
        Task<ContaBancariaDTO> ObterConta(string numConta, string agencia);
        Task<ResultResponse> RealizarDeposito(string numeroConta, string agencia, decimal valor);
        Task<ResultResponse> RealizarSaque(string numeroConta, string agencia, decimal valor);
        Task<ResultResponse> AplicarTaxaJuros(decimal taxa, string agencia, string conta);
        Task<ResultResponse> AplicarRendimento(decimal taxa, string agencia, string conta);
    }
}
