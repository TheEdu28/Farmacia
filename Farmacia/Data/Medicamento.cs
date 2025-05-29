using System.ComponentModel.DataAnnotations;

namespace Farmacia.Data
{
    public class Medicamento
    {
        public int ID_Medicamento { get; set; }
        [Required (ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]

        public string? Nombre { get; set; }
        [Required (ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(200, ErrorMessage = "La descripción no puede exceder los 200 caracteres.")]
        public string? Descripcion { get; set; }
        [Required (ErrorMessage = "El precio unitario es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor que cero.")]
        public decimal Precio_unitario { get; set; }
        [Required (ErrorMessage = "El stock actual es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock actual no puede ser negativo.")]
        public int Stock_actual { get; set; }
        [Required (ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de vencimiento no es válida.")]
        public DateTime Fecha_vencimiento { get; set; }
        [Required (ErrorMessage = "El ID del proveedor es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del proveedor debe ser mayor que cero.")]
        public int ID_Proveedor { get; set; }
    }
}
