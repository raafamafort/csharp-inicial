using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaslowApplication.Models
{
    public class Pagamento
    {
        [Key]
        public int PagamentoID { get; set; }

        [ForeignKey("Reserva")]
        public int ReservaID { get; set; }

        [Required]
        public DateTime DataPagamento { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public Reserva Reserva { get; set; }
    }
}
