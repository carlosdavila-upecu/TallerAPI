namespace Modelos
{
    public class ConsumoPorUsuarioDTO
    {
        public string idUsuario { get; set; }
        public string Nombre { get; set; }
        public int CantidadLlamadas { get; set; }
        public decimal TotalAPagar { get; set; }
    }
}
