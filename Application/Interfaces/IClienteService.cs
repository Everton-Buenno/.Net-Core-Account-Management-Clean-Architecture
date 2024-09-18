using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDto> AdicionarCliente(Cliente cliente);
        Task<ClienteDto> BuscarClientePorId(Guid clienteID);

        Task<List<ClienteDto>> BuscarTodosClientes();
    }
}
