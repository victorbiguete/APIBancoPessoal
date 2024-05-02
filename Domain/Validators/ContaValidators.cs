using APIBanco.Domain.Model;
using FluentValidation;

namespace APIBanco.Domain.Validators
{
    public class ContaValidators: AbstractValidator<Conta>
    {
        public ContaValidators() 
        {
            RuleFor(x=>x).NotEmpty().WithMessage("Conta não pode estar vazia")
                .NotNull().WithMessage("Conta não pode ser nula");

            RuleFor(x => x.Status).NotEmpty().WithMessage("Status não pode estar vazia")
                .NotNull().WithMessage("Status não pode ser nula");

            RuleFor(x => x.Agencia).NotEmpty().WithMessage("Agencia não pode estar vazia")
                .NotNull().WithMessage("Agencia não pode ser nula");

            RuleFor(x=>x.Numero).NotEmpty().WithMessage("O Numero não pode estar vazio")
                .NotNull().WithMessage("O Numero não pode ser nula");

            RuleFor(x=>x.Saldo).NotNull().WithMessage("Saldo não pode ser nula");

            RuleFor(x=>x.Titular).NotEmpty().WithMessage("Titular não pode estar vazia")
                .NotNull().WithMessage("Titular não pode ser nula");

            RuleFor(x=>x.TitularId).NotEmpty().WithMessage("Titular ID não pode estar vazia")
                .NotNull().WithMessage("Titular ID não pode ser nula");
        }    
    }
}
                                                                   