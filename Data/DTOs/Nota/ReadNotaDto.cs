using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Data.DTOs.Nota
{
    public class ReadNotaDto
    {
        public long? codigo { get; set; }

        public long? nota { get; set; }

        public long? serie { get; set; }

        public double? valorTotal { get; set; }

        [JsonIgnore]
        public long? empresaId { get; set; }

        public virtual Models.Empresa Empresa { get; set; }

    }
}
