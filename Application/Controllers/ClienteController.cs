using APIBanco.Application.ViewModel;
using APIBanco.Core.Exceptions;
using APIBanco.Domain.Model;
using APIBanco.Services.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIBanco.Application.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("/api/v1/cliente/create")]
        public async Task<IActionResult> Create([FromBody] CreateClienteViewModel clienteViewModel)
        {
            try
            {
                return Ok();
            }
            catch (DomainException ex)
            {
                return BadRequest();
            }
            catch(Exception e)
            {
                return StatusCode(500,"Erro");
            }
        }
    }
}
