using System.ComponentModel.DataAnnotations;

namespace Farmacia.Data
{
    public class Venta
    {
        public int ID_Venta { get; set; }

        [Required(ErrorMessage = "La fecha de venta es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha no es válido")]

        public DateTime Fecha_venta { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El medicamento es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del medicamento debe ser mayor a 0")]
        public int ID_Medicamento { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
        public int Cantidad_vendida { get; set; }

        [Required(ErrorMessage = "El total es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0")]
        public decimal Total_venta { get; set; }

        public int? ID_Cliente { get; set; }

        public Medicamento? Medicamento { get; set; }
    }
}
