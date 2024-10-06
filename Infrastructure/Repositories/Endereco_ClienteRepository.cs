using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Context;
using APIBanco.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIBanco.Infrastructure.Repositories
{
    public class Endereco_ClienteRepository : BaseRepository<Lista_Endereco_Cliente>, IEndereco_ClienteRepository
    {
        private readonly AppDbContext _context;

        public Endereco_ClienteRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Lista_Endereco_Cliente> GetEnderecoByClienteID(int clienteID)
        {
            var user = await _context.Lista_Endereco_Clientes.AsNoTracking().Where(x=>x.ClienteId==clienteID).FirstOrDefaultAsync();
            return user;
        }

        public async Task<Lista_Endereco_Cliente> GetEnderecoByEnderecoID(int enderecoID)
        {
            var endereco = await _context.Lista_Endereco_Clientes.AsNoTracking().Where(x=>x.EnderecoId==enderecoID).FirstOrDefaultAsync();
            return endereco;
        }
    }
}
