using Modelos;

namespace Negocio.Repositorio.IRepositorio
{
    public interface IRegistroRepositorio
    {
        Task<RegistroLlamadaDTO> RegistrarLlamada(RegistroLlamadaDTO llamadaDTO);
        Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadas();        
        Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadas(string idUsuario);
        Task<IEnumerable<ConsumoPorUsuarioDTO>> VerConsumoPorUsuario();
    }
}
