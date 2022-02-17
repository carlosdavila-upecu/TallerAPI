using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class RegistroUsuarioRequestDTO
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        public string NumeroTelefono { get; set; }

        [Required(ErrorMessage = "La tarifa es requerida")]
        public decimal Tarifa { get; set; }


        [Required(ErrorMessage = "La contrasenia es requerida.")]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "La confirmacion de la contrasenia es requerida")]
        [DataType(DataType.Password)]
        [Compare("Contrasenia", ErrorMessage = "Password and confirm password is not matched")]
        public string ConfirmacionContrasenia { get; set; }
    }
}
