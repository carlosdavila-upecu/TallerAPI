using Common;
using Data.Contexto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.InicializarDB
{
    public class InicializadorDB : IInicializadorDB
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _contexto;
        public InicializadorDB(UserManager<Usuario> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext contexto)
        {
            _contexto = contexto;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void InicializarDB()
        {
            try
            {
                if (_contexto.Database.GetPendingMigrations().Count() > 0)
                {
                    _contexto.Database.Migrate();
                }
                if (!_roleManager.RoleExistsAsync(Roles.Administrador).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(Roles.Administrador)).GetAwaiter().GetResult();
                }
                else
                {
                    return;
                }

                Usuario usuario = new()
                {
                    Nombre = "Carlos Davila",
                    UserName = "carlosdavila@tecnicoecuador.edu.ec",
                    Email = "carlosdavila@tecnicoecuador.edu.ec",
                    EmailConfirmed = true
                };

                _userManager.CreateAsync(usuario, "Admin1234*").GetAwaiter().GetResult();

                _userManager.AddToRoleAsync(usuario, Roles.Administrador).GetAwaiter().GetResult();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
