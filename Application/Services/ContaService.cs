using Application.DTOs;
using Application.Interfaces;
using Domain;
using Domain.Entities;
using Domain.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services
{
    public class ContaService : IContaService
    {

        private readonly IContaRepository _contaRepository;
        private readonly IClienteRepository _clienteRepository;
        public ContaService(IContaRepository contaRepository, IClienteRepository clienteRepository)
        {
            _contaRepository = contaRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<ResultResponse> AdicionarConta(CriarContaRequest conta)
        {
            var cliente = await _clienteRepository.BuscarClientePorId(conta.ClienteId);

            if (cliente is null)
                return new ResultResponse
                {
                    Error = true,
                    Message = "Erro ao criar conta, cliente não encontrado."
                };

            if (conta.TipoConta == TipoConta.Corrente)
            {
                var contaBancaria = new ContaCorrente(0, cliente);
                contaBancaria.GerarNumeroAgencia();
                contaBancaria.GerarNumeroConta();
                contaBancaria.GerarLimite();
                _contaRepository.AdicionarConta(contaBancaria);
            }
            else
            {
                var contaBancaria = new ContaPoupanca(0, cliente);
                contaBancaria.GerarNumeroAgencia();
                contaBancaria.GerarNumeroConta();
                _contaRepository.AdicionarConta(contaBancaria);
            }
            return new ResultResponse
            {
                Error = false,
                Message = "Conta criada com sucesso."
            };

        }

        public async Task<ResultResponse> AplicarRendimento(decimal taxa, string agencia, string numeroConta)
        {
            var conta = await _contaRepository.ObterConta(numeroConta, agencia);
            if (conta == null)
                return new ResultResponse
                {
                    Error = true,
                    Message = $"Conta não encontrada"
                };

            if (conta is ContaPoupanca contaPoupanca)
            {
                contaPoupanca.AplicarRendimento(taxa);
                await _contaRepository.AtualizarConta(contaPoupanca);
            }
            else
            {
                return new ResultResponse
                {
                    Error = true,
                    Message = $"Não é possível aplicar taxa de rendimentos em conta corrente."
                };
            }
            return new ResultResponse
            {
                Error = false,
                Message = $"Taxa de rendimentos de {taxa} aplicada com sucesso."
            };


        }

        public async Task<ResultResponse> AplicarTaxaJuros(decimal taxa, string agencia, string numeroConta)
        {
            var conta = await _contaRepository.ObterConta(numeroConta, agencia);
            if (conta == null)
                return new ResultResponse
                {
                    Error = true,
                    Message = $"Conta não encontrada"
                };

            if (conta is ContaCorrente contaCorrente)
            {
                if (contaCorrente.Saldo < 0)
                {
                    contaCorrente.AplicarJuros(taxa);
                    await _contaRepository.AtualizarConta(contaCorrente);
                }
            }else
            {
                return new ResultResponse
                {
                    Error = true,
                    Message = $"Não é possível aplicar taxa de juros em conta poupança."
                };
            }

            return new ResultResponse
            {
                Error = false,
                Message = $"Taxa de juros de {taxa} aplicada com sucesso."
            };
        }

        public async Task<ContaBancariaDTO> ObterConta(string numeroConta, string agencia)
        {
            var conta = await _contaRepository.ObterConta(numeroConta, agencia);

            if (conta is null)
                return null;

            return new ContaBancariaDTO
            {

                Id = conta.ContaID,
                NumeroConta = conta.NumeroConta,
                Agencia = conta.Agencia,
                TipoConta = conta.TipoConta == TipoConta.Corrente ? "Corrente" : "Poupanca",
                Saldo = conta.Saldo,
            };
        }

        public async Task<ResultResponse> RealizarDeposito(string numeroConta, string agencia, decimal valor)
        {
            var conta = await _contaRepository.ObterConta(numeroConta, agencia);
            if (conta is null)
                return new ResultResponse
                {
                    Error = true,
                    Message = "Conta não encontrada"
                };

            conta.Depositar(valor);
            await _contaRepository.AtualizarConta(conta);
            return new ResultResponse
            {
                Error = false,
                Message = "Deposito efetuado com sucesso."
            };

        }

        public async Task<ResultResponse> RealizarSaque(string numeroConta, string agencia, decimal valor)
        {
            var conta = await _contaRepository.ObterConta(numeroConta, agencia);
            if (conta is null)
                return new ResultResponse
                {
                    Error = true,
                    Message = "Conta não encontrada"
                };

            var result = conta.Sacar(valor);
            if (!result)
                return new ResultResponse
                {
                    Error = true,
                    Message = "Não foi possível efetuar saque, saldo insuficiente."
                };

            await _contaRepository.AtualizarConta(conta);
            return new ResultResponse
            {
                Error = false,
                Message = "Saque efetuado com sucesso."
            };
        }
    }
}
