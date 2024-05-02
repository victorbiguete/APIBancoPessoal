using AutoMapper;
using APIBanco.Domain.Model;
using APIBanco.Services.DTOs;

namespace APIBanco.Infrastructure.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            //T -> Cliente, U -> ClienteDTO
            //Criei o DTO Generico pra facilitar o mapeamento, vamos ver se funciona
            CreateMap<Conta, ContaDTO>();
            CreateMap<ContaDTO, Conta>();

            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();


        }
    }
}
