namespace Modelos
{
    public class UsuarioDTO
    {
        public virtual string Id { get; set; }
        public int Nombre { get; set; }
        public int PhoneNumber { get; set; }
        public decimal Tarifa { get; set; }
    }
}
