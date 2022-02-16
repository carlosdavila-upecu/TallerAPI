﻿using Modelos;

namespace Negocio.Repositorio.IRepositorio
{
    public interface IRegistroRepositorio
    {
        Task<RegistroLlamadaDTO> RegistrarLlamada(RegistroLlamadaDTO llamadaDTO);
        Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadas();
        Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadasUsuario(string idUsuario);
    }
}