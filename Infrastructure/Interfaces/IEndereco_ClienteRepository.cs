using APIBanco.Domain.Model;

namespace APIBanco.Infrastructure.Interfaces
{
    public interface IEndereco_ClienteRepository:IBaseRepository<Lista_Endereco_Cliente>
    {
        Task<Lista_Endereco_Cliente> GetEnderecoByClienteID(int clienteID);
        Task<Lista_Endereco_Cliente> GetEnderecoByEnderecoID(int enderecoID);
    }
}
