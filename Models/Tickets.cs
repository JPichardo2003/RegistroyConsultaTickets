using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace TicketsApp.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(30, ErrorMessage = "No puede exceder los 30 Caracteres")]
        public string? SolicitadoPor { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        [ForeignKey("PrioridadId")]
        public int PrioridadId { get; set; }

        [ForeignKey("SistemaId")]
        public int SistemaId { get; set; }
    }
}
