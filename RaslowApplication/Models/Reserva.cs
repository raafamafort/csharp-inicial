using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaslowApplication.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaID { get; set; }

        [ForeignKey("Hospede")]
        public int HospedeID { get; set; }

        [ForeignKey("Quarto")]
        public int QuartoID { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; }

        [Required]
        public DateTime DataSaida { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }

        public Hospede Hospede { get; set; }
        public Quarto Quarto { get; set; }

        public ICollection<Pagamento> Pagamentos { get; set; }
    }

}
