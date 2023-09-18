using System.ComponentModel.DataAnnotations;

namespace TicketsApp.Models
{
    public class Sistemas
    {
        [Key]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? NombreSistema { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? DescripcionSistema { get; set; }
    }
}
