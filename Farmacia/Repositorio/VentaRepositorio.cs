using Farmacia.Data;
using Microsoft.EntityFrameworkCore;

namespace Farmacia.Repositorio
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly FarmaciaDbContext _context;

        public VentaRepositorio(FarmaciaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Venta>> ObtenerVentasAsync()
        {
            return await _context.Ventas.Include(v => v.Medicamento).ToListAsync();
        }

        public async Task<Venta> ObtenerVentaPorIdAsync(int id)
        {
            // CORREGIR ESTOS ERRORES DE SINTAXIS
            return await _context.Ventas.Include(v => v.Medicamento)
                .FirstOrDefaultAsync(v => v.ID_Venta == id);
        }

        public async Task AgregarVentaAsync(Venta venta)
        {
            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarVentaAsync(Venta venta)
        {
            try
            {
                // Verificar que la entidad existe
                var ventaExistente = await _context.Ventas.FindAsync(venta.ID_Venta);
                if (ventaExistente == null)
                {
                    throw new Exception($"Venta con ID {venta.ID_Venta} no encontrada");
                }

                // Actualizar las propiedades
                ventaExistente.Fecha_venta = venta.Fecha_venta;
                ventaExistente.ID_Medicamento = venta.ID_Medicamento;
                ventaExistente.Cantidad_vendida = venta.Cantidad_vendida;
                ventaExistente.Total_venta = venta.Total_venta;
                ventaExistente.ID_Cliente = venta.ID_Cliente;

                // Marcar como modificado explícitamente
                _context.Entry(ventaExistente).State = EntityState.Modified;

                var rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected == 0)
                {
                    throw new Exception("No se pudo actualizar la venta - ninguna fila afectada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ActualizarVentaAsync: {ex.Message}");
                throw;
            }
        }

        public async Task EliminarVentaAsync(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Venta>> ObtenerRangoFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Ventas
                .Where(v => v.Fecha_venta >= fechaInicio && v.Fecha_venta <= fechaFin)
                .Include(v => v.Medicamento)
                .ToListAsync();
        }
    }
}