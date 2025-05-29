using Farmacia.Data;
using Microsoft.EntityFrameworkCore;

namespace Farmacia.Repositorio
{
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly FarmaciaDbContext _context;

        public ProveedorRepositorio(FarmaciaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Proveedor>> ObtenerProveedoresAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor> ObtenerProveedorPorIdAsync(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task AgregarProveedorAsync(Proveedor proveedor)
        {
            await _context.Proveedores.AddAsync(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarProveedorAsync(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarProveedorAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
