using ControleDeProdutos_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Data.DTOs.Cliente
{
    public class UpdateClienteDto
    {
        [Required(ErrorMessage = "Campo Nome Obrigatório!")]
        [StringLength(60)]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo Cpf Obrigatório!")]
        public long? cpf { get; set; }

        [Required(ErrorMessage = "Campo Tipo do Cliente Obrigatório!")]
        public TipoCliente tipoCliente { get; set; }

        public long empresaId { get; set; }
    }
}
