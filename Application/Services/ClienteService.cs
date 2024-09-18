using Application.DTOs;
using Application.Interfaces;
using Domain;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDto> AdicionarCliente(Cliente cliente)
        {
            var result = await _clienteRepository.AdicionarCliente(cliente);
            if (result is null)
                return null;


            return new ClienteDto
            {
                Id = result.Id,
                Nome = result.Nome,
                Endereco = result.Endereco,
                Cpf = MascararCpf(result.Cpf),
                Profissao = result.Profissao,
            };
        }
        public async Task<ClienteDto> BuscarClientePorId(Guid clienteID)
        {
            var result = await _clienteRepository.BuscarClientePorId(clienteID);
            if (result is null)
                return null;

            var contasDto = result.Contas.Select(c => new ContaBancariaDTO
            {
                Id = c.ContaID,
                NumeroConta = c.NumeroConta,
                Agencia = c.Agencia,
                TipoConta = c.TipoConta == TipoConta.Corrente ? "Corrente" : "Poupanca",
                Saldo = c.Saldo,
                Limite = c is ContaCorrente ? ((ContaCorrente)c).Limite : 0
            }).ToList();

            return new ClienteDto
            {
                Id = result.Id,
                Nome = result.Nome,
                Endereco = result.Endereco,
                Cpf = MascararCpf(result.Cpf),
                Profissao = result.Profissao,
                ContasBancaria = contasDto 
            };
        }
        private static string MascararCpf(string cpf)
        {
            if (cpf.Length < 11) 
                return cpf; 
            return new string('*', cpf.Length - 4) + cpf.Substring(cpf.Length - 4);
        }

        public async Task<List<ClienteDto>> BuscarTodosClientes()
        {
            var clientes = await _clienteRepository.BuscarTodosClientes();

            var clientesDto = clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Endereco = c.Endereco,
                Cpf = c.Cpf,
                Profissao = c.Profissao,
                ContasBancaria = c.Contas?.Select(cb => new ContaBancariaDTO
                {
                    Id = cb.ContaID,
                    NumeroConta = cb.NumeroConta,
                    Agencia = cb.Agencia,
                    Saldo = cb.Saldo,
                    TipoConta = cb.TipoConta == TipoConta.Corrente ? "Corrente" : "Poupanca",
                    Limite = cb is ContaCorrente ? ((ContaCorrente)cb).Limite : 0
                }).ToList()
            }).ToList();

            return clientesDto;
        }
    }
}
