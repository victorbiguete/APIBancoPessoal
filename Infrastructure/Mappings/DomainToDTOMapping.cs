using AutoMapper;
using APIBanco.Domain.Model;
using APIBanco.Services.DTOs;

namespace APIBanco.Infrastructure.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            
            CreateMap<Conta, ContaDTO>().AfterMap((src, dest) =>
            {
                dest.Numero=src.Numero;
                dest.Titular=src.Titular;
                dest.TitularId=src.TitularId;
            });
            CreateMap<ContaDTO, Conta>().AfterMap((src, dest) =>
            {
                dest.Numero = src.Numero;
                dest.Titular = src.Titular;
                dest.TitularId = src.TitularId;
            });

            CreateMap<Cliente, ClienteDTO>().AfterMap((src, dest) =>
            {
                dest.Contas=src.Contas;
                dest.Id = (long)src.Contas.TitularId;
            });
            CreateMap<ClienteDTO, Cliente>().AfterMap((src, dest) =>
            {
                dest.Contas.TitularId= src.Id;
                dest.Contas = src.Contas;
            });


        }
    }
}
