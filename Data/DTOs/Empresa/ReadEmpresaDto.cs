using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Data.DTOs.Empresa

{
    public class ReadEmpresaDto
    {
        [Key]
        [Required]
        public long? codigo { get; set; }
        public string descricao { get; set; }
        public long cnpj { get; set; }

        public DateTime horaConsulta { get; set; } 
    }
}
