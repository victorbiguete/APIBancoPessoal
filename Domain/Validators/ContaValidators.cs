using APIBanco.Domain.Model;
using FluentValidation;

namespace APIBanco.Domain.Validators
{
    public class ContaValidators: AbstractValidator<Conta>
    {
        public ContaValidators() 
        {
            RuleFor(x=>x).NotEmpty().WithMessage("A entidade não pode estar vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");
            
            RuleFor(x => x.Status).NotEmpty().WithMessage("A entidade não pode estar vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");
            
            RuleFor(x=>x.Agencia).NotEmpty().WithMessage("A entidade não pode estar vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");
            
            RuleFor(x=>x.Numero).NotEmpty().WithMessage("A entidade não pode estar vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");

            RuleFor(x=>x.Saldo).NotEmpty().WithMessage("A entidade não pode estar vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");

            RuleFor(x=>x.Titular).NotEmpty().WithMessage("A entidade não pode estar vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");

            RuleFor(x=>x.TitularId).NotEmpty().WithMessage("A entidade não pode estar vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");
        }    
    }
}
                                                                   