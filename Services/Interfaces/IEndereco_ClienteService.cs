using APIBanco.Services.DTOs;

namespace APIBanco.Services.Interfaces
{
    public interface IEndereco_ClienteService
    {
        Task<Endereco_ClienteDTO> Create(Endereco_ClienteDTO endereco_cliente);
        Task<Endereco_ClienteDTO> Update(Endereco_ClienteDTO endereco_cliente);
        Task Remove(long id);
        Task<Endereco_ClienteDTO> Get(long id);
        Task<List<Endereco_ClienteDTO>> SearchByClienteId(long id);
    }
}
