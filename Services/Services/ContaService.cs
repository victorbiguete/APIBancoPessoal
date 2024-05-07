using APIBanco.Core.Exceptions;
using APIBanco.Domain.Model;
using APIBanco.Domain.Validators;
using APIBanco.Infrastructure.Interfaces;
using APIBanco.Services.DTOs;
using APIBanco.Services.Interfaces;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;

namespace APIBanco.Services.Services
{
    public class ContaService:IContaService
    {
        private readonly IContaRepositoy _contaRepositoyLeitura;
        private readonly IContaRepositoy _contaRepositoyGravacao;
        private readonly IMapper _mapper;

        public ContaService(IContaRepositoy contaRepositoyLeitura, IContaRepositoy contaRepositoyGravacao, IMapper mapper)
        {
            _contaRepositoyLeitura = contaRepositoyLeitura;
            _contaRepositoyGravacao = contaRepositoyGravacao;
            _mapper = mapper;
        }

        public async Task<ContaDTO> Create(Cliente cliente)
        {
            try
            {
                var numeroConta = await GerarNumerodeConta();

                var contaDTO = new ContaDTO(numeroConta, cliente.Id, cliente);

                var conta = _mapper.Map<Conta>(contaDTO);
            conta.Validate();

                var contaCreated = await _contaRepositoyGravacao.Create(conta);
            return _mapper.Map<ContaDTO>(contaCreated);
        }
            catch (Exception ex)
            {
                throw new DomainException("Houve um erro durante a criação da conta");
            }

        }

        public async Task Delete(long id)
        {
            var contaExist = await _contaRepositoyLeitura.Get(id);
            if (contaExist == null)
                throw new DomainException("Não foi possivel localizar essa conta");

            await _contaRepositoyGravacao.Delete(id);
        }

        public async Task<ContaDTO> Get(long id)
        {
            var contaExist = await _contaRepositoyLeitura.Get(id);
            if (contaExist == null)
                throw new DomainException("Não foi possivel localizar a conta");

            return _mapper.Map<ContaDTO>(contaExist);
        }

        public async Task<ContaDTO> GetByConta(string numero)
        {
            var contaExist = await _contaRepositoyLeitura.GetByConta(numero);
            
            if (contaExist == null)
                throw new DomainException("Não foi possivel localizar a conta");
            
            return _mapper.Map<ContaDTO>(contaExist);
        }

        public async Task<List<ContaDTO>> SearchByContaByCPF(string cpf)
        {
            var contaExist = await _contaRepositoyLeitura.SearchByContaByCPF(cpf);

            if (contaExist == null)
                throw new DomainException("Não foi possive localizar nenhuma conta");

            return _mapper.Map<List<ContaDTO>>(contaExist);
        }

        public async Task<ContaDTO> Update(ContaDTO contaDTO)
        {
            var contaExist = await _contaRepositoyLeitura.GetByConta(contaDTO.Numero);

            if (contaExist == null)
                throw new DomainException("Não foi possivel localizar nenhuma conta");

            

            var conta = _mapper.Map<Conta>(contaExist);
            conta.Validate();
            Conta.StatusConta(0, conta);
            var contaUpdate = await _contaRepositoyGravacao.Update(conta);

            return _mapper.Map<ContaDTO>(contaUpdate);
        }

        public async Task<string> GerarNumerodeConta()
        {
            dynamic contaExist;

            Random random = new Random();

            string numeroConta;
            
            do
            {
                numeroConta = random.Next(100).ToString();
                contaExist = await _contaRepositoyLeitura.GetByConta(numeroConta);

            } while (contaExist != null);

            return numeroConta;
        }

        public async Task<List<ContaDTO>> GetAll()
        {
            var conta = await _contaRepositoyLeitura.GetAll();
            return _mapper.Map<List<ContaDTO>>(conta);
        }
    }
}
