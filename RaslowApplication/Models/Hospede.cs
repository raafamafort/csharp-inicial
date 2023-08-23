using System.ComponentModel.DataAnnotations;

namespace RaslowApplication.Models
{
    public class Hospede
    {
        [Key]
        public int HospedeID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        public Reserva Reserva { get; set; }
    }
}
