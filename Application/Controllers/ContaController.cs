using APIBanco.Application.Utilities;
using APIBanco.Application.ViewModel;
using APIBanco.Core.Exceptions;
using APIBanco.Domain.Model;
using APIBanco.Services.DTOs;
using APIBanco.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIBanco.Application.Controllers
{
    public class ContaController : Controller
    {
        private readonly IContaService _contaService;
        private readonly IMapper _mapper;

        public ContaController(IContaService contaService, IMapper mapper)
        {
            _contaService = contaService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/v1/contas/GetAccount")]
        public async Task<IActionResult> GetAccount()
        {
            try
            {
                var Account = await _contaService.GetAll();
                return Ok(new ResultViewModel
                {
                    Message = "Busca concluida com sucesso",
                    Success = true,
                    Data = Account
                });
            }
            catch(DomainException ex) { return BadRequest(Responses.DomainErrorMessage(ex.Message,ex.Errors)); }
            catch (Exception ex) { return StatusCode(500, Responses.ApplicationErrorMessage(ex.Message)); }
        }

        [HttpPut]
        [Route("api/v1/conta/encerrarconta")]
        public async Task<IActionResult> EncerrarConta(string numero)
        {
            try
            {
                var contaDTO = await _contaService.GetByConta(numero);
                
                var contaUpdated = await _contaService.Update(contaDTO);

                return Ok(new ResultViewModel
                {
                    Message="Conta do Usuario Encerrada",
                    Success = true,
                    Data = contaUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
                
            }
            catch(Exception e)
            {
                return StatusCode(500,Responses.ApplicationErrorMessage(e.Message));
            }

        }
    }
}
