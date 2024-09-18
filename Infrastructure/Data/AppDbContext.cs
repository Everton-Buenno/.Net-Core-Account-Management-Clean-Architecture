using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContaBancaria> Contas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ContaBancaria>()
                .HasKey(c => c.ContaID);

            modelBuilder.Entity<ContaBancaria>()
                .HasOne(c => c.Cliente)
                .WithMany(ac => ac.Contas)
                .HasForeignKey(c => c.ClienteID);

            modelBuilder.Entity<ContaBancaria>()
                .ToTable("ContasBancarias");

            modelBuilder.Entity<ContaCorrente>()
                .ToTable("ContasCorrentes"); 

            modelBuilder.Entity<ContaPoupanca>()
                .ToTable("ContasPoupancas"); 



        }
    }
}
