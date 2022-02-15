using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public decimal Tarifa { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ICollection<RegistroLlamada> Llamadas { get; set; }
    }
}
