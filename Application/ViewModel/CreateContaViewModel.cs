using APIBanco.Domain.Enum;
using APIBanco.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace APIBanco.Application.ViewModel
{
    public class CreateContaViewModel
    {
        public string Numero { get; set; }
        public int Agencia { get; set; } = 1;
        public decimal Saldo { get; private set; } = 0;
        public long TitularId { get; set; }
        public virtual Cliente Titular { get; set; } = null!;
        public StatusServico Status { get; set; } = StatusServico.Ativo;
    }
}
