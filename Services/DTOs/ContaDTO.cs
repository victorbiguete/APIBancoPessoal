using APIBanco.Domain.Enum;
using APIBanco.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace APIBanco.Services.DTOs
{
    public class ContaDTO
    {
        public long Id { get; set; }
        public string Numero { get; set; }     
        public long? TitularId { get; set; }
        public virtual Cliente Titular { get; set; }
        

        public ContaDTO()
        {
        }

        public ContaDTO(string numero, long? titularId, Cliente titular)
        {
            Numero = numero;
            TitularId = titularId;
            Titular = titular;
        }

        
    }
}
