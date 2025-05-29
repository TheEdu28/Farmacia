using System.ComponentModel.DataAnnotations;

namespace Farmacia.Data
{
    public class Proveedor
    {
        public int ID_Proveedor { get; set; }
        [Required (ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string? Nombre_empresa { get; set; }
        [Required (ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede exceder los 15 caracteres.")]
        public string? Telefono { get; set; }
        [Required (ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string? Correo { get; set; }
        [Required (ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(100, ErrorMessage = "La dirección no puede exceder los 100 caracteres.")]
        public string? Direccion { get; set; }
    }
}
