namespace Modelos
{
    public class RegistroLlamadaDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public string NumeroDestino { get; set; }
        public int Minutos { get; set; }
        public DateTime FechaLlamada { get; set; }
    }
}
