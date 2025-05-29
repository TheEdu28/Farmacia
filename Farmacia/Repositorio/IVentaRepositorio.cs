using Farmacia.Data;

namespace Farmacia.Repositorio
{
    public interface IVentaRepositorio
    {
        Task<List<Venta>> ObtenerVentasAsync();
        Task<Venta> ObtenerVentaPorIdAsync(int id);
        Task AgregarVentaAsync(Venta venta);
        Task ActualizarVentaAsync(Venta venta);
        Task EliminarVentaAsync(int id);
        Task<List<Venta>> ObtenerRangoFechaAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}
