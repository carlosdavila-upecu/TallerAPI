using Modelos;

namespace Negocio.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<UsuarioDTO>> ObtenerUsuarios();
    }
}
