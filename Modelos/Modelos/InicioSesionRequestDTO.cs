using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class InicioSesionRequestDTO
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Correo invalido")]
        public string Correo { get; set; }


        [Required(ErrorMessage = "La contrasenia es requerida")]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }
    }
}
