using APIBanco.Services.DTOs;

namespace APIBanco.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO> Create(ClienteDTO cliente);
        Task<ClienteDTO> Update(ClienteDTO cliente);
        Task Remove(long id);
        Task<ClienteDTO> Get(long id);
        Task<List<ClienteDTO>> GetAll();
        Task<List<ClienteDTO>> SearchByName(string name);
        Task<List<ClienteDTO>> SearchByUsername(string username);
        Task<ClienteDTO> GetByEmail(string name);
    }
}
