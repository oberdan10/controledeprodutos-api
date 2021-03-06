using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Models
{
    public class Empresa
    {
        [Key]
        public long codigo { get; set; }

        [Required(ErrorMessage = "Campo Descrição Obrigatório!")]
        [StringLength(60)]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo CNPJ Obrigatório!")]
        public long cnpj { get; set; }

        [JsonIgnore]
        public virtual List<Funcionario>? Funcionario { get; set; }

        [JsonIgnore]
        public virtual List<Cliente>? Cliente { get; set; }

        [JsonIgnore]
        public virtual List<Nota>? Nota { get; set; }
    }
}
