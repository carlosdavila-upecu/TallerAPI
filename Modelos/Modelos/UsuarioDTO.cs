namespace Modelos
{
    public class UsuarioDTO
    {
        public virtual string Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public decimal Tarifa { get; set; }
    }
}
