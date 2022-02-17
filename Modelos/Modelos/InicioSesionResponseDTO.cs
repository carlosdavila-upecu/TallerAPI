namespace Modelos
{
    public class InicioSesionResponseDTO
    {
        public bool AutenticacionSatisfecha { get; set; }
        public string MensajeError { get; set; }
        public string Token { get; set; }
        public UsuarioDTO UsuarioDTO { get; set; }
    }
}
