using AutoMapper;
using Data.Contexto;
using Modelos;
using Negocio.Repositorio.IRepositorio;

namespace Negocio.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _contexto;
        private readonly IMapper _mapper;
        public UsuarioRepositorio(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObtenerUsuarios()
        {
            return _mapper.Map<IEnumerable<UsuarioDTO>>(_contexto.Usuarios);
        }
    }
}
