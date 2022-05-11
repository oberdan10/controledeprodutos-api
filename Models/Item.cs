using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeProdutos_API.Models
{

    public class Item
    {
        [Key]
        public long? codigo { get; set; }

        [Required(ErrorMessage = "Campo Descrição Obrigatório!")]
        [StringLength(60)]
        public string? descricao { get; set; }

        [Required(ErrorMessage = "Campo Observação Obrigatório!")]
        [StringLength(200)]
        public string? observacao { get; set; }

        [Required(ErrorMessage = "Campo Lote Obrigatório!")]
        [StringLength(30)]
        public string? lote { get; set; }

        public virtual Categoria Categoria { get; set; }

        public long categoriaId { get; set; }

    }
}
