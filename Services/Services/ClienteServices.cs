using APIBanco.Core.Exceptions;
using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Interfaces;
using APIBanco.Services.DTOs;
using APIBanco.Services.Interfaces;
using AutoMapper;

namespace APIBanco.Services.Services
{
    public class ClienteServices : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IContaService _contaService;

        public ClienteServices(IMapper mapper, IClienteRepository clienteRepository, IContaService contaService)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _contaService= contaService;
        }

        public async Task<ClienteDTO> Create(ClienteDTO clienteDTO)
        {
            var userExists = await _clienteRepository.GetByEmail(clienteDTO.Email);    
           

            if (userExists != null)
            {
                throw new DomainException("Já existe um usuario cadastrado com esse email");
            }

            userExists = await _clienteRepository.GetByCPF(clienteDTO.Cpf);

            if (userExists != null)
            {
                throw new DomainException("Já existe um usuario cadastrado com esse CPF");
            }

            

            var user = _mapper.Map<Cliente>(clienteDTO);
            user.Validate();
            var userCreated = await _clienteRepository.Create(user);

            var conta = await _contaService.Create(userCreated);

            if(conta == null)
            {
                _clienteRepository.Delete(userCreated.Id);
                throw new DomainException("Erro durante a criação da conta");
            }

            //var conta = _mapper.Map<Conta>(contaDTO);
            //conta.Validate();

            //var contaCreated = await _contaRepositoy.Create(conta);

            var userCreated = await _clienteRepository.Create(user);

            return _mapper.Map<ClienteDTO>(userCreated);
        }

        public async Task<ClienteDTO> Get(long id)
        {
            var userExists = await _clienteRepository.Get(id);

            if (userExists == null)
            {
                throw new DomainException("Não foi localizado nenhum Cliente por esse ID");
            }

            return _mapper.Map<ClienteDTO>(userExists);
        }

        public async Task<List<ClienteDTO>> GetAll()
        {
            var allUser = await _clienteRepository.GetAll();

            if (allUser == null)
                throw new DomainException("Não existe nenhum cliente");

            return _mapper.Map<List<ClienteDTO>>(allUser);
        }

        public async Task<ClienteDTO> GetByEmail(string email)
        {
            var userExist = await _clienteRepository.GetByEmail(email);

            if (userExist == null)
            {
                throw new DomainException("Nenhum email foi localizado");
            }

            return _mapper.Map<ClienteDTO>(userExist);
        }

        public async Task Remove(long id)
        {
            var userExists = await _clienteRepository.Get(id);

            if (userExists == null)
            {
                throw new DomainException("Cliente não localizado");
            }

            await _clienteRepository.Delete(id);
        }

        public Task<List<ClienteDTO>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClienteDTO>> SearchByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<ClienteDTO> Update(ClienteDTO clienteDTO)
        {
            var userExists = await _clienteRepository.Get(clienteDTO.Id);
            
            if(userExists == null)
            {
                throw new DomainException("Cliente não encontrado");
            }

            var user = _mapper.Map<Cliente>(clienteDTO);
            user.Validate();

            var userUpdate = await _clienteRepository.Update(user);

            return _mapper.Map<ClienteDTO>(userUpdate);
        }
    }
}
