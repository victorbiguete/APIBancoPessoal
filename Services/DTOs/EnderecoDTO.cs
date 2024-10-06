using System.ComponentModel.DataAnnotations;

namespace APIBanco.Services.DTOs
{
    public class EnderecoDTO
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

        public EnderecoDTO(int cEP, string tipoCEP, string uF, string cidade, string bairro, string endereco, string complemento)
        {
            CEP = cEP;
            this.tipoCEP = tipoCEP;
            UF = uF;
            Cidade = cidade;
            Bairro = bairro;
            Endereco = endereco;
            Complemento = complemento;
        }

        public EnderecoDTO()
        {
        }
    }
}
