using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IContaRepository
    {
        void AdicionarConta(ContaBancaria conta);
        Task<ContaBancaria> ObterConta(string numeroConta, string agencia);

        Task AtualizarConta(ContaBancaria conta);
    }
}
