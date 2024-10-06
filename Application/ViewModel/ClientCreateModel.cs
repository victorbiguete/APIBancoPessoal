using APIBanco.Domain.Model;
using APIBanco.Services.DTOs;

namespace APIBanco.Application.ViewModel
{
    public class ClientCreateModel
    {
        public ClienteDTO Cliente { get; set; }
        public EnderecoDTO Endereco { get; set;}
    }
}
