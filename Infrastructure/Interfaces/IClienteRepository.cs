using APIBanco.Domain.Model;
using APIBanco.Services.DTOs;

namespace APIBanco.Infrastructure.Interfaces
{
    public interface IClienteRepository:IBaseRepository<Cliente>
    {
        Task<Cliente> GetByEmail(string email);
        Task<Cliente> GetByCPF(string cpf);
        Task<List<Cliente>> SearchByUsername(string username);
        Task<List<Cliente>> SearchByEmail(string email);
        Task<List<Cliente>> SearchByName(string name);
    }
}
