using APIBanco.Application.Utilities;
using APIBanco.Application.ViewModel;
using APIBanco.Core.Exceptions;
using APIBanco.Domain.Model;
using APIBanco.Services.DTOs;
using APIBanco.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIBanco.Application.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/cliente/create")]
        public async Task<IActionResult> Create([FromBody] CreateClienteViewModel clienteViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<ClienteDTO>(clienteViewModel);
                //var contaDTO = _mapper.Map<ContaDTO>();
                var user = await _clienteService.Create(userDTO);

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
                //return StatusCode(500,Responses.ApplicationErrorMessage());
                return BadRequest(e.Message);
            }
        }
    }
}
