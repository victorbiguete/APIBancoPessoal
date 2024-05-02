using APIBanco.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APIBanco.Application.ViewModel
{
    public class CreateClienteViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "O Nome deve ter no minimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O Nome deve ter no Maximo 80 caracteres")]
        public string Nome { get; private set; }

        [Required]
        [Length(14, 14, ErrorMessage = "CPF está do tamanho errado")]
        public string Cpf { get; private set; }
        //public virtual Conta Contas { get; set; }
        public decimal? Renda { get; private set; }

        [Required]
        [DataType("Data")]
        public DateTime DataNascimento { get; private set; }

        [DataType("Data")]
        public DateTime? DataObito { get; private set; } = null;

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; private set; }

        [Required]
        [PasswordPropertyText]
        [Length(10, 180, ErrorMessage = "Verifique se a senha esta nos padrões minimos e maximos exigitos")]
        public string Password { get; private set; }

        public CreateClienteViewModel(string nome, string cpf, decimal? renda, DateTime dataNascimento, string email, string password)
        {
            Nome = nome;
            Cpf = cpf;
            Renda = renda;
            DataNascimento = dataNascimento;
            Email = email;
            Password = password;
        }
    }
}
