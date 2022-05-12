using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Data.DTOs.Nota
{
    public class UpdateNotaDto
    {
        public long? codigo { get; set; }

        public int? nota { get; set; }

        public int? serie { get; set; }

        public long? empresaId { get; set; }
    }
}
