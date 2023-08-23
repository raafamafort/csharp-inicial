using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaslowApplication.Models
{
    public class Quarto
    {
        [Key]
        public int QuartoID { get; set; }

        [Required]
        public string NumeroQuarto { get; set; }

        [Required]
        public decimal PrecoPorNoite { get; set; }

        [ForeignKey("TipoQuarto")]
        public int TipoQuartoID { get; set; }

        public TipoQuarto TipoQuarto { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
