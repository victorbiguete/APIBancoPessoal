using APIBanco.Domain.Model;

namespace APIBanco.Infrastructure.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<EnderecoCliente>
    {
        Task<EnderecoCliente> GetByCEP(int cep);
        Task<EnderecoCliente> GetById(int id);
    }
}
