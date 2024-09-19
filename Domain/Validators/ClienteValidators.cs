using APIBanco.Domain.Model;
using FluentValidation;

namespace APIBanco.Domain.Validators
{
    public class ClienteValidators:AbstractValidator<Cliente>
    {
        public ClienteValidators()
        {
            RuleFor(x => x).NotEmpty().WithMessage("A entidade não pode ser vazia")
                .NotNull().WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Nome).NotEmpty().WithMessage("A Nome não pode ser vazia")
                .NotNull().WithMessage("A Nome não pode ser nula.")
                .MinimumLength(3).WithMessage("O Nome deve ter no minimo 3 caracteres")
                .MaximumLength(80).WithMessage("O Nome deve ter no Maximo 80 caracteres");

            RuleFor(x => x.Email).NotEmpty().WithMessage("A Email não pode ser vazia")
                .NotNull().WithMessage("A Email não pode ser nula.")
                .MinimumLength(10).WithMessage("O Email deve ter no minimo 3 caracteres")
                .MaximumLength(180).WithMessage("O Email deve ter no Maximo 80 caracteres")
                .Matches(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Email informado não é valido")
                .EmailAddress().WithMessage("Formato de email invalido");

            RuleFor(x => x.Password).NotEmpty().WithMessage("A Senha não pode ser vazia")
                .NotNull().WithMessage("A Senha não pode ser nula.")
                .MinimumLength(10).WithMessage("O Senha deve ter no minimo 3 caracteres")
                .MaximumLength(180).WithMessage("O Senha deve ter no Maximo 80 caracteres");

            RuleFor(x => x.Cpf).NotEmpty().WithMessage("CPF não pode ser vazio")
                .NotNull().WithMessage("CPF não pode ser nulo")
                .Length(11,11).WithMessage("CPF está do tamanho errado");

            RuleFor(x => x.DataNascimento).NotNull().WithMessage("Data de Nascimento não pode ser Nulo")
                .NotEmpty().WithMessage("Data de Nascimento não pode estar vazio");
                
            
        }
    }
}
