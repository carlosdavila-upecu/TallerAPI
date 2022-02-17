namespace Modelos
{
    public class RegistroUsuarioResponseDTO
    {
        public bool RegistroSatisfactorio { get; set; }
        public IEnumerable<string> Errores { get; set; }
    }
}
