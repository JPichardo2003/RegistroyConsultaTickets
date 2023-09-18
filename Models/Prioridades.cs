using System.ComponentModel.DataAnnotations;

namespace TicketsApp.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Descripcion { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "DiasCompromiso debe ser mayor que 0.")]
        public int DiasCompromiso { get; set; }
    }
}

