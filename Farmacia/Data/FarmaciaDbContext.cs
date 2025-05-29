using Microsoft.EntityFrameworkCore;

namespace Farmacia.Data
{
    public class FarmaciaDbContext : DbContext
    {
        public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options)
        : base(options)
        {
        }

        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Medicamento
            modelBuilder.Entity<Medicamento>()
                .HasKey(m => m.ID_Medicamento);

            modelBuilder.Entity<Medicamento>()
                .Property(m => m.Precio_unitario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Medicamento>()
                .HasOne<Proveedor>()
                .WithMany()
                .HasForeignKey(m => m.ID_Proveedor)
                .OnDelete(DeleteBehavior.Restrict);

            // Proveedor
            modelBuilder.Entity<Proveedor>()
                .HasKey(p => p.ID_Proveedor);

            // Venta
            modelBuilder.Entity<Venta>()
                .HasKey(v => v.ID_Venta);

            modelBuilder.Entity<Venta>()
                .Property(v => v.Total_venta)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Medicamento)
                .WithMany()
                .HasForeignKey(v => v.ID_Medicamento)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

        }

    }
}
