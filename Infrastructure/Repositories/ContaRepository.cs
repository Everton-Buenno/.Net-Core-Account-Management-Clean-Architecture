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


    public class ContaRepository : IContaRepository
    {

        private readonly AppDbContext _context;

        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async void AdicionarConta(ContaBancaria conta)
        {
            await _context.Contas.AddAsync(conta);
            await _context.SaveChangesAsync();
        }

        public async Task<ContaBancaria> ObterConta(string numeroConta, string agencia)
        {
            return await _context.Contas.FirstOrDefaultAsync(c => c.NumeroConta == numeroConta && c.Agencia == agencia);
        }

        public async Task AtualizarConta(ContaBancaria conta)
        {
            _context.Contas.Update(conta);
            await _context.SaveChangesAsync();
        }
       
    }
}
