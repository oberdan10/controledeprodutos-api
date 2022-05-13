using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Data.DTOs.Funcionario
{
    public class UpdateFuncionarioDto
    {

        [Required(ErrorMessage = "Campo Nome Obrigatório!")]
        [StringLength(60)]
        public string? nome { get; set; }

        [Required(ErrorMessage = "Campo CPF Obrigatório!")]
        public long? cpf { get; set; }

    }
}
