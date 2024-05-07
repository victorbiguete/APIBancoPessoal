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

            CreateMap<Cliente, ClienteUpdateDTO>();
            CreateMap<ClienteUpdateDTO, Cliente>();
            

            CreateMap<ClienteUpdateDTO, Cliente>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
            .ForMember(dest => dest.Renda, opt => opt.MapFrom(src => src.Renda))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.DataObito, opt => opt.MapFrom(src => src.DataObito))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<Cliente, ClienteUpdateDTO>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
            .ForMember(dest => dest.Renda, opt => opt.MapFrom(src => src.Renda))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.DataObito, opt => opt.MapFrom(src => src.DataObito))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));


        }
    }
}
