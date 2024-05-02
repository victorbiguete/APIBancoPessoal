using APIBanco.Domain.Model;

namespace APIBanco.Infrastructure.Interfaces
{
    public interface IContaRepositoy:IBaseRepository<Conta>
    {
        Task<Conta> GetByConta(string numero);
        Task<List<Conta>> SearchByContaByCPF(string cpf);
        
    }
}
