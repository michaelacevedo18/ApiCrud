using System.ComponentModel.DataAnnotations;

namespace ApiCrud.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public long Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Verificado { get; set; }
    }
}
