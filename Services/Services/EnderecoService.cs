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
                throw new DomainException("Ocorreu um erro durante o CREATE de ENDERECO, por favor verifique: " + ex.Message);
            }
        }

        public async Task<EnderecoDTO> Get(long id)
        {
            try
            {
                var endereco = await _enderecoRepository.Get(id);

                if(endereco == null)
                {
                    return null;
                }
                return _mapper.Map<EnderecoDTO>(endereco);
            }
            catch (Exception ex)
            {
                throw new DomainException("Ocorreu um erro durante o GET de ENDERECO, por favor verifique: " + ex.Message);
            }
        }

        public async Task<EnderecoDTO> GetByCEP(int cep)
        {
            try
            {
                var endereco = await _enderecoRepository.GetByCEP(cep);

                if (endereco == null)
                    return null;

                return _mapper.Map<EnderecoDTO>(endereco);
            }
            catch(Exception ex)
            {
                throw new DomainException("Ocorreu um erro durante o GETBYCEP de ENDERECO, por favor verifique: " + ex.Message);
            }
        }

        public async Task<bool> Remove(long id)
        {
            try
            {
                var endereco = await _enderecoRepository.Get(id);
                if(endereco != null)
                {
                    await _enderecoRepository.Delete(id );
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new DomainException("Ocorreu um erro durante o REMOVE de ENDERECO, por favor verifique: " + ex.Message);
            }
        }

        public async Task<EnderecoDTO> Update(EnderecoDTO enderecoDTO)
        {
            try
            {
                var enderecoNovo = _mapper.Map<EnderecoCliente>(enderecoDTO);
                enderecoNovo.Validate();
                var enderecoUpdate = await _enderecoRepository.Update(enderecoNovo);
                
                return _mapper.Map<EnderecoDTO>(enderecoUpdate);
            }
            catch(Exception ex)
            {
                throw new DomainException("Ocorreu um erro durante o UPDATE de ENDERECO, por favor verifique: " + ex.Message);
            }
        }
    }
}
