using APIBanco.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace APIBanco.Services.DTOs
{
    public class ClienteUpdateDTO
    {
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }
        public decimal? Renda { get; set; }

        [Required]
        [DataType("Data")]
        public DateTime DataNascimento { get; set; }

        [DataType("Data")]
        public DateTime? DataObito { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        [JsonIgnore]
        public string Password { get; set; }
    }
}
