using Domain;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly AppDbContext _dbContext;
        public ClienteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }
        public async Task<Cliente> BuscarClientePorId(Guid clienteID)
        {
            return await _dbContext.Clientes
                .Include(o => o.Contas).FirstOrDefaultAsync(c => c.Id == clienteID);
        }

        public async Task<List<Cliente>> BuscarTodosClientes()
        {
            return await _dbContext.Clientes.Include(c => c.Contas).ToListAsync();
        }
    }
}
