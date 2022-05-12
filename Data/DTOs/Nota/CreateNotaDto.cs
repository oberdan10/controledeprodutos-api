using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Data.DTOs.Nota
{
    public class CreateNotaDto
    {

        public int? nota { get; set; }

        public int? serie { get; set; }

        public long? empresaId { get; set; }
    }
}
