using APIBanco.Application.Utilities;
using APIBanco.Application.ViewModel;
using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Context;
using APIBanco.Token;
using Microsoft.AspNetCore.Mvc;

namespace APIBanco.Application.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("/api/v1/auth/login")]
        public IActionResult Auth([FromBody]LoginViewModel loginViewModel)
        {
            try
            {
                //Trocar para Usuario e Senha do Usuario
                var tokenLogin = _configuration["Jwt:Login"];
                var tokenPassword = _configuration["Jwt:Password"];

                if (loginViewModel.Login.Equals(tokenLogin) && loginViewModel.Password.Equals(tokenPassword))
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Usuario autenticado com Sucesso !",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"])),
                        }
                    });
                }
                else
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
            }
            catch (Exception ex)
            {
                return StatusCode(500,Responses.ApplicationErrorMessage(""));
            }
        }
    }
}
