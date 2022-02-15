using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class RegistroLlamada
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; }
        public string NumeroDestino { get; set; }
        public int Minutos { get; set; }
        public DateTime FechaLlamada { get; set; }
    }
}
