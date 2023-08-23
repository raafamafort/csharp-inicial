using System.ComponentModel.DataAnnotations;

namespace RaslowApplication.Models
{
    public class TipoQuarto
    {
        [Key]
        public int TipoQuartoID { get; set; }

        [Required]
        public string Descricao { get; set; }

        public ICollection<Quarto> Quartos { get; set; }
    }
}
