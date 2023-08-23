using System.ComponentModel.DataAnnotations;

namespace RaslowApplication.Models
{
    public class Alunos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
