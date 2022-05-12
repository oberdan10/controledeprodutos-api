using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Data.DTOs.Funcionario
{
    public class ReadFuncionarioDto
    {
        [Key]
        [Required]
        public long? codigo { get; set; }

        [Required(ErrorMessage = "Campo Nome Obrigatório!")]
        [StringLength(60)]
        public string? nome { get; set; }

        [Required(ErrorMessage = "Campo CPF Obrigatório!")]
        [StringLength(11)]
        public string? cpf { get; set; }
        public DateTime horaConsulta { get; set; } 
    }
}
