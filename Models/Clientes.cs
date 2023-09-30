using System.ComponentModel.DataAnnotations;

namespace TicketsApp.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [StringLength(30, ErrorMessage = "No Puede Exceder los 30 Caracteres")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Nombres { get; set; }
        [StringLength(10, ErrorMessage = "No Puede Exceder los 10 Caracteres")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Telefono { get; set; }
        [StringLength(15, ErrorMessage = "No Puede Exceder los 15 Caracteres")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Celular { get; set; }
        [StringLength(9, ErrorMessage = "No Puede Exceder los 9 Caracteres")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Rnc { get; set; }
        [StringLength(30, ErrorMessage = "No Puede Exceder los 30 Caracteres")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Email { get; set; }
        [StringLength(50, ErrorMessage = "No Puede Exceder los 50 Caracteres")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Direccion { get; set; }

    }
}