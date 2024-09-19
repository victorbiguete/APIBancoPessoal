using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIBanco.Domain.Model
{
    public class EnderecoCliente : Base
    {
        [Required]
        public int CEP { get; private set; }
        
        [Required]
        public string tipoCEP { get; private set; }
        
        [Required]
        public string UF { get; private set; }
        
        [Required]
        public string Cidade { get; private set; }
        
        [Required]
        public string Bairro { get; private set; }
        
        [Required]
        public string Endereco { get; private set; }
        
        [Required]
        public string Complemento { get; private set; }

        [InverseProperty(nameof(Lista_Endereco_Cliente.Endereco))]
        public Lista_Endereco_Cliente lista_endereco_cliente { get; private set; }

        public EnderecoCliente(int cEP, string tipoCEP, string uF, string cidade, string bairro, string endereco, string complemento)
        {
            CEP = cEP;
            this.tipoCEP = tipoCEP;
            UF = uF;
            Cidade = cidade;
            Bairro = bairro;
            Endereco = endereco;
            Complemento = complemento;
        }

        public EnderecoCliente()
        {
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
