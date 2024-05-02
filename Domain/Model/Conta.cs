using Microsoft.Extensions.Options;
using APIBanco.Domain.Enum;
using APIBanco.Domain.Validators;
using APIBanco.Core.Exceptions;
using APIBanco.Services.Services;

namespace APIBanco.Domain.Model
{
    public class Conta:Base
    {
        
        public string Numero { get; set; }
        public int Agencia { get; set; } = 1;
        public decimal Saldo { get; private set; } = 0;
        public long? TitularId { get; set; }
        public virtual Cliente Titular { get; set; } = null!;
        public StatusServico Status { get; set; } = StatusServico.Ativo;

        public Conta()
        {
            //int numero;

            //Random random = new Random();

            //do
            //{
            //    numero = random.Next(100);
            //    var contaService = new ContaService();
            //}
            
        }

        public Conta(string numero, int agencia, decimal saldo, Cliente titular)
        {
            Saldo = saldo;
            Numero = numero;
            Agencia = agencia;
            Titular = titular;
        }

        public bool Sacar(decimal valor)
        {
            if (Saldo < valor)
            {
                throw new ArgumentOutOfRangeException("Valor do Saque", valor, "Saldo insuficiente");
            }
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("Valor do Saque", valor, "Valor do saque deve ser maior que 0");
            }

            Saldo -= valor;
            return true;
        }
        public bool Depositar(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException("Deposito Invalido", valor.ToString(), "Valor para deposito não pode ser " +
                    "negativo");

            Saldo += valor;
            return true;
        }
        public bool Trasferir(Conta destino, decimal valor)
        {
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                return true;
            }
            return false;
        }

        //TODO
        public override bool Validate()
        {
            var validator = new ContaValidators();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                throw new DomainException("Alguns campos estão invalidos, por favor corrija-os", _errors);

            }
            return true;
        }
    }
}

