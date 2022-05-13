using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Models
{
    public class Cliente
    {
        [Key]
        public long? codigo { get; set; }

        [Required(ErrorMessage = "Campo Nome Obrigatório!")]
        [StringLength(60)]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo Cpf Obrigatório!")]
        public long? cpf { get; set; }

        [Required(ErrorMessage = "Campo Tipo do Cliente Obrigatório!")]
        public TipoCliente tipoCliente { get; set; }

        public virtual Empresa Empresa { get; set; }

        [JsonIgnore]
        public long empresaId { get; set; }
    }
}
