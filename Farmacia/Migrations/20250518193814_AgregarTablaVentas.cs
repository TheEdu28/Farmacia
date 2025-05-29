using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmacia.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablaVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    ID_Venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_venta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Medicamento = table.Column<int>(type: "int", nullable: false),
                    Cantidad_vendida = table.Column<int>(type: "int", nullable: false),
                    Total_venta = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ID_Cliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.ID_Venta);
                    table.ForeignKey(
                        name: "FK_Ventas_Medicamentos_ID_Medicamento",
                        column: x => x.ID_Medicamento,
                        principalTable: "Medicamentos",
                        principalColumn: "ID_Medicamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ID_Medicamento",
                table: "Ventas",
                column: "ID_Medicamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
