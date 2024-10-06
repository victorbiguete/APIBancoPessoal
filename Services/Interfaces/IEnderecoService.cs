using APIBanco.Services.DTOs;

namespace APIBanco.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<EnderecoDTO> Create(EnderecoDTO enderecoDTO);
        Task<EnderecoDTO> Update(EnderecoDTO enderecoDTO);
        Task Remove(long id);
        Task<EnderecoDTO> Get(long id);
    }
}
