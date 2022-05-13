using System.ComponentModel.DataAnnotations;

namespace ControleDeProdutos_API.Models
{
    public enum TipoCliente
    {
        [Display(Name="Fisico")]
        Fisico,
        [Display(Name = "Juridico")]
        Juridico
    }
}
