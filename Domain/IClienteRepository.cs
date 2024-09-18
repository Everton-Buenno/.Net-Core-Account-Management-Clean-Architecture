using Domain.Entities;

namespace Domain
{
    public interface IClienteRepository
    {
        Task<Cliente> AdicionarCliente(Cliente cliente);
        Task<Cliente> BuscarClientePorId (Guid clienteID);

        Task<List<Cliente>> BuscarTodosClientes();

    }
}
