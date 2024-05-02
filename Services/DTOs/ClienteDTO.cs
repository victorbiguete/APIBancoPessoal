using APIBanco.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using APIBanco.Services.Interfaces;

namespace APIBanco.Services.DTOs
{
    public class ClienteDTO
    {
        public long Id { get; set; }    

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }
        public virtual Conta Contas { get; set; }
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
        public string Password { get; set; }

        public ClienteDTO()
        {
            
        }

        public ClienteDTO(long id, string nome, string cpf, Conta contas, decimal? renda, DateTime dataNascimento, DateTime? dataObito, string email, string password)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Contas = contas;
            Renda = renda;
            DataNascimento = dataNascimento;
            DataObito = dataObito;
            Email = email;
            Password = password;
        }

       
    }
}
