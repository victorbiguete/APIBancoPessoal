using APIBanco.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using APIBanco.Services.Interfaces;
using System.Text.Json.Serialization;
using APIBanco.Security;

namespace APIBanco.Services.DTOs
{
    public class ClienteDTO
    {
        public long Id { get; set; }    

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }
        
        public decimal? Renda { get;  set; }

        [Required]
        [DataType("Data")]
        public DateTime DataNascimento { get;  set; }

        [DataType("Data")]
        public DateTime? DataObito { get;  set; }

        [Required]
        [EmailAddress]
        public string Email { get;  set; }

        [Required]
        [PasswordPropertyText]
        [JsonIgnore]
        public string Password { get; set; }

        public ClienteDTO()
        {
            
        }

        public ClienteDTO(long id, string nome, string cpf, decimal? renda, DateTime dataNascimento, DateTime? dataObito, string email, string password)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Renda = renda;
            DataNascimento = dataNascimento;
            DataObito = dataObito;
            Email = email;
            Password = BCryptPassword.HashPassword(password);
        }
    }
}
