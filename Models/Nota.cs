using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Models
{
    public class Nota
    {
        [Key]
        public long? codigo { get; set; }

        public long? nota { get; set; }

        public long? serie { get; set; }

        public double? valorTotal { get; set; }

        public virtual Empresa Empresa { get; set; }

        [JsonIgnore]
        public long? empresaId { get; set; }
    }
}
