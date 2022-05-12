using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Data.DTOs.Categoria
{
    public class CreateCategoriaDto
    {

        [Required(ErrorMessage = "Campo Descrição Obrigatório!")]
        [StringLength(60)]
        public string? descricao { get; set; }

        [Required(ErrorMessage = "Campo Família Obrigatório!")]
        [StringLength(60)]
        public string? familia { get; set; }

    }
}
