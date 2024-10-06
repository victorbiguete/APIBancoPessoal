using APIBanco.Application.Utilities;
using APIBanco.Application.ViewModel;
using APIBanco.Core.Exceptions;
using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Interfaces;
using APIBanco.Services.DTOs;
using APIBanco.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIBanco.Application.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService,IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _clienteService = clienteService;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/api/v1/cliente/create")]
        public async Task<IActionResult> Create([FromBody] ClientCreateModel Model)//([FromBody] CreateClienteViewModel clienteViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<ClienteDTO>(Model.Cliente);
                var enderecoDTO = _mapper.Map<EnderecoDTO>(Model.Endereco);
                var user = await _clienteService.Create(userDTO);
                var endereco = await _enderecoSer.Create(enderecoDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuario criado com Sucesso",
                    Success = true,
                    Data = user
                });
                //return Ok();
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception e)
            {
                return StatusCode(500,Responses.ApplicationErrorMessage(e.Message));
                //return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/api/v1/cliente/update")]
        public async Task<IActionResult> Update([FromBody] UpdateClienteViewModel clienteUpdateDTO)
        {
            try
            {
                var clienteDTO = _mapper.Map<ClienteDTO>(clienteUpdateDTO);
                var updateDTO = await _clienteService.Update(clienteDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Cliente atualizado com sucesso",
                    Success = true,
                    Data = updateDTO
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(e.Message));
            }
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/api/v1/cliente/GetCliente")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var clientes = await _clienteService.GetAll();
                
                return Ok(clientes);
            }
            catch(DomainException ex)
            {
                return null;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        
    }
}
