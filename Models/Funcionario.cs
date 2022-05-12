using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Models
{
    public class Funcionario
    {
        [Key]
        public long codigo { get; set; }

        [Required(ErrorMessage = "Campo Nome Obrigatório!")]
        [StringLength(60)]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo cpf Obrigatório!")]
        [StringLength(11)]
        public string cpf { get; set; }

        public virtual Empresa Empresa { get; set; }

        [JsonIgnore]
        public long empresaId { get; set; }
    }
}
