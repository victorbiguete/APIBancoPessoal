using System.ComponentModel.DataAnnotations.Schema;

namespace APIBanco.Domain.Model
{
    public class Lista_Endereco_Cliente:Base
    {
        [ForeignKey("cliente")]
        public long ClienteId { get; set; }

        [InverseProperty(nameof(Cliente.lista_endereco_cliente))]
        public Cliente cliente { get; set; }

        [ForeignKey("Endereco")]
        public long EnderecoId { get; set; }

        [InverseProperty(nameof(EnderecoCliente.lista_endereco_cliente))]
        public EnderecoCliente Endereco { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
