using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Data.DTOs.Item
{
    public class UpdateItemDto
    {

        [Required(ErrorMessage = "Campo Descrição Obrigatório!")]
        [StringLength(60)]
        public string? descricao { get; set; }

        [Required(ErrorMessage = "Campo Observação Obrigatório!")]
        [StringLength(200)]
        public string? observacao { get; set; }

        [Required(ErrorMessage = "Campo Lote Obrigatório!")]
        [StringLength(30)]
        public string? lote { get; set; }

        public long categoriaId { get; set; }
    }
}
