using AutoMapper;
using APIBanco.Domain.Model;
using APIBanco.Services.DTOs;

namespace APIBanco.Infrastructure.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Cliente,ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteUpdateDTO>().ReverseMap();
           
            CreateMap<Conta, ContaDTO>().ReverseMap();
        }
    }
}
