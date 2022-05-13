using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Data.DTOs.Nota
{
    public class UpdateNotaDto
    {
        public long? codigo { get; set; }

        public long? nota { get; set; }

        public long? serie { get; set; }

        public double? valorTotal { get; set; }

        public long? empresaId { get; set; }
    }
}
