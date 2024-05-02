using APIBanco.Domain.Enum;

namespace APIBanco.Domain.Model
{
    public class Servicos
    {
        public int Id { get; set; }
        public TipoTransferencia Tipo { get; set; }
        public int Qtde { get; set; }

        //TODO CRUD e ToString()
    }
}
