using APIBanco.Domain.Model;
using APIBanco.Services.DTOs;

namespace APIBanco.Services.Interfaces
{
    public interface IContaService
    {
        Task<ContaDTO> Create(Cliente cliente);
        Task<ContaDTO> Update(ContaDTO contaDTO);
        Task Delete(long id);
        Task<ContaDTO> Get(long id);
        Task<ContaDTO> GetByConta(string numero);
        Task<List<ContaDTO>> SearchByContaByCPF(string cpf);

    }
}
