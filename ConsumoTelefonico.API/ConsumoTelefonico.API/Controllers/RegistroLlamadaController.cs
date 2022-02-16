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

        [HttpPost]
        public async Task<IActionResult> Crear(RegistroLlamadaDTO llamadaDTO)
        {
            var resultado = await _registroRepositorio.RegistrarLlamada(llamadaDTO);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLlamadas()
        {
            return Ok(await _registroRepositorio.VerRegistroLlamadas());
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ObtenerLlamadas(string idUsuario)
        {
            return Ok(await _registroRepositorio.VerRegistroLlamadas(idUsuario));
        }
    }
}
