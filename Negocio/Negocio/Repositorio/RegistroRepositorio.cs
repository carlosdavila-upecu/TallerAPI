using AutoMapper;
using Data;
using Data.Contexto;
using Modelos;
using Negocio.Repositorio.IRepositorio;

namespace Negocio.Repositorio
{
    public class RegistroRepositorio : IRegistroRepositorio
    {
        private readonly ApplicationDbContext _contexto;
        private readonly IMapper _mapper;
        public RegistroRepositorio(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }
        
        public async Task<RegistroLlamadaDTO> RegistrarLlamada(RegistroLlamadaDTO llamadaDTO)
        {
            var llamada = _mapper.Map<RegistroLlamada>(llamadaDTO);
            var nuevaLlamada = _contexto.Add(llamada);
            await _contexto.SaveChangesAsync();
            return _mapper.Map<RegistroLlamadaDTO>(nuevaLlamada);
        }

        public async Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadas()
        {
            return _mapper.Map<IEnumerable<RegistroLlamadaDTO>>(_contexto.RegistroLlamadas);
        }

        public async Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadas(string idUsuario)
        {
            var listaLlamadas = _contexto.RegistroLlamadas.Where(llamada => llamada.UserId == idUsuario);
            return _mapper.Map<IEnumerable<RegistroLlamadaDTO>>(listaLlamadas);
        }

        public async Task<IEnumerable<ConsumoPorUsuarioDTO>> VerConsumoPorUsuario()
        {
            return _contexto.RegistroLlamadas
                        .GroupBy(registro => new
                        {
                            registro.UserId,
                            registro.Usuario.Nombre,
                            registro.Usuario.Tarifa
                        })
                        .Select(grupo => new ConsumoPorUsuarioDTO
                        {
                            idUsuario = grupo.Key.UserId,
                            Nombre = grupo.Key.Nombre,
                            CantidadLlamadas = grupo.Count(),
                            TotalAPagar = grupo.Sum(registro => registro.Minutos * grupo.Key.Tarifa)
                        });
        }
    }
}
