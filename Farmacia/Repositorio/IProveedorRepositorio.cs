using Farmacia.Data;

namespace Farmacia.Repositorio
{
    public interface IProveedorRepositorio
    {
        Task<List<Proveedor>> ObtenerProveedoresAsync();
        Task<Proveedor> ObtenerProveedorPorIdAsync(int id);
        Task AgregarProveedorAsync(Proveedor proveedor);
        Task ActualizarProveedorAsync(Proveedor proveedor);
        Task EliminarProveedorAsync(int id);
    }
}
