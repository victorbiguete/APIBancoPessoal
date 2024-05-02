using APIBanco.Domain.Model;

namespace APIBanco.Infrastructure.Interfaces
{
    public interface IClienteRepository:IBaseRepository<Cliente>
    {
        Task<Cliente> GetByEmail(string email);
        Task<List<Cliente>> SearchByEmail(string email);
        Task<List<Cliente>> SearchByName(string name);
    }
}
