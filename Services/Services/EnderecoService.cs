using APIBanco.Core.Exceptions;
using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Context;
using APIBanco.Infrastructure.Interfaces;
using APIBanco.Services.DTOs;
using APIBanco.Services.Interfaces;
using AutoMapper;

namespace APIBanco.Services.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<EnderecoDTO> Create(EnderecoDTO enderecoDTO)
        {
            try
            {
                var endereco = _mapper.Map<EnderecoCliente>(enderecoDTO);
                endereco.Validate();
                var enderecoCreated = await _enderecoRepository.Create(endereco);
                return _mapper.Map<EnderecoDTO>(enderecoCreated);
            }
            catch(Exception ex)
            {
                throw new DomainException("Houve um erro durante a criação da conta:"+ex.Message);
            }
        }

        public Task<EnderecoDTO> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoDTO> Update(EnderecoDTO enderecoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
