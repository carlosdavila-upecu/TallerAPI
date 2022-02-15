using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexto
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RegistroLlamada> RegistroLlamadas { get; set; }
    }
}
