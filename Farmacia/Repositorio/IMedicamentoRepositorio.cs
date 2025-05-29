using Farmacia.Data;

namespace Farmacia.Repositorio
{
    public interface IMedicamentoRepositorio
    {
        Task<List<Medicamento>> ObtenerMedicamentosAsync();
        Task<Medicamento> ObtenerMedicamentoPorIdAsync(int id);
        Task AgregarMedicamentoAsync(Medicamento medicamento);
        Task ActualizarMedicamentoAsync(Medicamento medicamento);
        Task EliminarMedicamentoAsync(int id);
    }
}
