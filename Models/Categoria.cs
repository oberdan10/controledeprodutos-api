using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Models
{
    public class Categoria
    {
        [Key]
        public long? codigo { get; set; }

        [Required(ErrorMessage = "Campo Descrição Obrigatório!")]
        [StringLength(60)]
        public string? descricao { get; set; }

        [Required(ErrorMessage = "Campo Família Obrigatório!")]
        [StringLength(60)]
        public string? familia { get; set; }

        [JsonIgnore]
        public virtual List<Item>? Item  { get; set; }
    }
}
