using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Data.DTOs.Empresa
{
    public class UpdateEmpresaDto
    {

        [Required(ErrorMessage = "Campo Descrição Obrigatório!")]
        [StringLength(60)]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo CNPJ Obrigatório!")]
        [StringLength(14)]
        public string cnpj { get; set; }

    }
}
