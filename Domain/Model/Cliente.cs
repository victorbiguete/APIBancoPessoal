using APIBanco.Core.Exceptions;
using APIBanco.Domain.Validators;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIBanco.Domain.Model
{
    public class Cliente : Base
    {
        
        [Required]
        [MinLength(3,ErrorMessage = "O Nome deve ter no minimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O Nome deve ter no Maximo 80 caracteres")]
        public string Nome { get; private set; }

        [Required]
        [Length(11,14,ErrorMessage = "CPF está do tamanho errado")]
        public string Cpf { get; private set; }
        

        public decimal? Renda { get; private set; }

        [Required]
        [DataType("Data")]
        public DateTime DataNascimento { get; private set; }

        [DataType("Data")]
        public DateTime? DataObito { get; private set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; private set; }

        [Required]
        [PasswordPropertyText]
        [Length(10,180,ErrorMessage ="Verifique se a senha esta nos padrões minimos e maximos exigitos")]
        public string Password { get; private set; }

        [InverseProperty(nameof(Conta.Titular))]
        public Conta conta { get; private set; }

        [InverseProperty(nameof(Lista_Endereco_Cliente.cliente))]
        public Lista_Endereco_Cliente lista_endereco_cliente { get; private set; }

        protected Cliente() { }

        public Cliente(string nome, string cpf, decimal? renda, DateTime dataNascimento, DateTime? dataObito, string email, string password)
        {
            Nome = nome;
            Cpf = cpf;
            Renda = renda;
            DataNascimento = dataNascimento;
            DataObito = dataObito;
            Email = email;
            Password = password;
        }

        public override bool Validate()
        {
            var validator = new ClienteValidators();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                throw new DomainException("Alguns campos estão invalidos, por favor corrija-os", _errors);
            }

            return true; 
        }    
    }
}

