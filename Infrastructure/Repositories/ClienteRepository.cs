using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Context;
using APIBanco.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIBanco.Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext dbContext):base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Cliente> GetByCPF(string cpf)
        {
            var user = await _context.Clientes.AsNoTracking().Where(x=>x.Cpf.Equals(cpf)).FirstOrDefaultAsync();
            return user;
        }

        public async Task<Cliente> GetByEmail(string email)
        {
            var user = await _context.Clientes
                .AsNoTracking()
                .Where(x=> x.Email.Equals(email))
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<Cliente>> SearchByEmail(string email)
        {
            var user = await _context.Clientes
                .AsNoTracking()
                .Where(x => x.Email.ToLower().Contains(email.ToLower()))
                .ToListAsync();

            return user;
        }

        public async Task<List<Cliente>> SearchByName(string name)
        {
            var user = await _context.Clientes
                .AsNoTracking()
                .Where(x => x.Nome.ToLower().Contains(name.ToLower()))
                .ToListAsync();
            return user;
        }
    }
}
