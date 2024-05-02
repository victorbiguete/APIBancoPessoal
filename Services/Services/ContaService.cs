using APIBanco.Core.Exceptions;
using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Interfaces;
using APIBanco.Services.DTOs;
using APIBanco.Services.Interfaces;
using AutoMapper;

namespace APIBanco.Services.Services
{
    public class ContaService:IContaService
    {
        private readonly IContaRepositoy _contaRepositoy;
        private readonly IMapper _mapper;

        public ContaService(IContaRepositoy contaRepositoy, IMapper mapper)
        {
            _contaRepositoy = contaRepositoy;
            _mapper = mapper;
        }

        public async Task<ContaDTO> Create(ContaDTO contaDTO)
        {
            var contaExist = await _contaRepositoy.GetByConta(contaDTO.Numero);
            if (contaExist != null)
                throw new DomainException("Essa conta já existe");

            var conta=_mapper.Map<Conta>(contaDTO);
            conta.Validate();

            var contaCreated = await _contaRepositoy.Create(conta);
            return _mapper.Map<ContaDTO>(contaCreated);
        }

        public async Task Delete(long id)
        {
            var contaExist = await _contaRepositoy.Get(id);
            if (contaExist == null)
                throw new DomainException("Não foi possivel localizar essa conta");

            await _contaRepositoy.Delete(id);
        }

        public async Task<ContaDTO> Get(long id)
        {
            var contaExist = await _contaRepositoy.Get(id);
            if (contaExist == null)
                throw new DomainException("Não foi possivel localizar a conta");

            return _mapper.Map<ContaDTO>(contaExist);
        }

        public async Task<ContaDTO> GetByConta(string numero)
        {
            var contaExist = await _contaRepositoy.GetByConta(numero);
            
            if (contaExist == null)
                throw new DomainException("Não foi possivel localizar a conta");
            
            return _mapper.Map<ContaDTO>(contaExist);
        }

        public async Task<List<ContaDTO>> SearchByContaByCPF(string cpf)
        {
            var contaExist = await _contaRepositoy.SearchByContaByCPF(cpf);

            if (contaExist == null)
                throw new DomainException("Não foi possive localizar nenhuma conta");

            return _mapper.Map<List<ContaDTO>>(contaExist);
        }

        public async Task<ContaDTO> Update(ContaDTO contaDTO)
        {
            var contaExist = await _contaRepositoy.Get(contaDTO.Id);

            if (contaExist == null)
                throw new DomainException("Não foi possivel localizar nenhuma conta");

            var conta = _mapper.Map<Conta>(contaExist);
            conta.Validate();

            var contaUpdate = await _contaRepositoy.Update(conta);

            return _mapper.Map<ContaDTO>(contaUpdate);
        }
    }
}
