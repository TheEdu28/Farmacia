using Farmacia.Data;
using Microsoft.EntityFrameworkCore;

namespace Farmacia.Repositorio
{
    public class MedicamentoRepositorio : IMedicamentoRepositorio
    {
        private readonly FarmaciaDbContext _context;
        public MedicamentoRepositorio(FarmaciaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Medicamento>> ObtenerMedicamentosAsync()
        {
            return await _context.Medicamentos.ToListAsync();
        }
        public async Task<Medicamento> ObtenerMedicamentoPorIdAsync(int id)
        {
            return await _context.Medicamentos.FindAsync(id);
        }
        public async Task AgregarMedicamentoAsync(Medicamento medicamento)
        {
            await _context.Medicamentos.AddAsync(medicamento);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarMedicamentoAsync(Medicamento medicamento)
        {
            _context.Medicamentos.Update(medicamento);
            var rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected == 0)
            {
                throw new Exception("No se pudo actualizar el medicamento");
            }
        }
        public async Task EliminarMedicamentoAsync(int id)
        {
            var medicamento = await ObtenerMedicamentoPorIdAsync(id);
            if (medicamento != null)
            {
                _context.Medicamentos.Remove(medicamento);
                await _context.SaveChangesAsync();
            }
        }

    }
}
