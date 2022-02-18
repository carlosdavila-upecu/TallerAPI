using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Negocio.Repositorio.IRepositorio;

namespace ConsumoTelefonico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroLlamadaController : ControllerBase
    {
        private readonly IRegistroRepositorio _registroRepositorio;

        public RegistroLlamadaController(IRegistroRepositorio registroRepositorio)
        {
            _registroRepositorio = registroRepositorio;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Crear(RegistroLlamadaDTO llamadaDTO)
        {
            llamadaDTO.FechaLlamada = DateTime.Now;
            var resultado = await _registroRepositorio.RegistrarLlamada(llamadaDTO);
            return Ok(resultado);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ObtenerLlamadas()
        {
            return Ok(await _registroRepositorio.VerRegistroLlamadas());
        }

        [Authorize]
        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ObtenerLlamadas(string idUsuario)
        {
            return Ok(await _registroRepositorio.VerRegistroLlamadas(idUsuario));
        }

        [Authorize(Roles = Roles.Administrador)]
        [HttpGet("[action]")]
        public async Task<IActionResult> ObtenerConsumoLlamadas()
        {
            return Ok(await _registroRepositorio.VerConsumoPorUsuario());
        }
    }
}
