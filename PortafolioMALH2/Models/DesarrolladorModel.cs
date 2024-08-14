using System.ComponentModel.DataAnnotations;

namespace PortafolioMALH2.Models
{
    public class DesarrolladorModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60)]
        public string? NombreCompleto { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimineto { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números.")]
        [StringLength(10)]
        public string? NumCel { get; set; }

        [StringLength(30)]
        public string? CorreoElec { get; set; }
        public string? ImagenURL { get; set; }
        public string? Descripcion { get; set; }
    }
}
