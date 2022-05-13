using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Data.DTOs.Nota
{
    public class CreateNotaDto
    {

        public long? nota { get; set; }

        public long? serie { get; set; }

        public double? valorTotal { get; set; }

        public long? empresaId { get; set; }
    }
}
