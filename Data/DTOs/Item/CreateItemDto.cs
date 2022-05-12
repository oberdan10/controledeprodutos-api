using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Data.DTOs.Item
{
    public class CreateItemDto
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

        [Required(ErrorMessage = "Campo Categoria Obrigatório!")]
        public string categoriaId { get; set; }
    }
}
