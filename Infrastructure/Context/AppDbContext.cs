using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIBanco.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Tarifa> Tarifa { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new ContaMap());
            //builder.ApplyConfiguration(new TarifaMap());
        }
    }
}
