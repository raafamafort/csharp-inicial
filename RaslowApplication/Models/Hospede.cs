using System.ComponentModel.DataAnnotations;

namespace RaslowApplication.Models
{
    public class Hospede
    {
        public int HospedeID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Reserva Reserva { get; set; }
    }
}
