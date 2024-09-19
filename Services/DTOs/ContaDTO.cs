using APIBanco.Domain.Enum;
using APIBanco.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIBanco.Services.DTOs
{
    public class ContaDTO
    {
        public long Id { get; set; }
        public string Numero { get; set; }
        public long TitularId { get; set; }

        public ContaDTO()
        {
        }

        public ContaDTO(string numero, long titularId )
        {
            Numero = numero;
            TitularId = titularId;
        }

        
    }
}
