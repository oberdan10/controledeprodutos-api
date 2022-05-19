using ControleDeProdutos_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeProdutos_API.Data.DTOs.Cliente
{
    public class ReadClienteJuridicoDto
    {

        public long? codigo { get; set; }
        public string nome { get; set; }
        public long? cpf { get; set; }
        public TipoCliente tipoCliente { get; set; }

        public virtual Models.Empresa Empresa { get; set; }
        [JsonIgnore]
        public long? empresaId { get; set; }

    }
}
