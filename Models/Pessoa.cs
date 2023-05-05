using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        public ICollection<Contato>? Contatos { get; set; }
    }
}
