using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Context;
using APIBanco.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIBanco.Infrastructure.Repositories
{
    public class EnderecoRepository : BaseRepository<EnderecoCliente>, IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<EnderecoCliente> GetByCEP(int cep)
        {
            var endereco = await _context.enderecoClientes
                .AsNoTracking()
                .Where(x=>x.CEP==cep)
                .FirstOrDefaultAsync();
            return endereco;
        }

        public async Task<EnderecoCliente> GetById(int id)
        {
            var endereco = await _context.enderecoClientes
                .AsNoTracking()
                .Where(x=>x.Id==id)
                .FirstOrDefaultAsync();
            return endereco;
        }
    }
}
