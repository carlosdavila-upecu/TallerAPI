using AutoMapper;
using Data;
using Modelos;

namespace Negocio.Mapper
{
    public class PerfilesMapper : Profile
    {
        public PerfilesMapper()
        {
            CreateMap<RegistroLlamada, RegistroLlamadaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
