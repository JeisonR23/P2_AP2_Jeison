using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jeison_Par2_AP1.Migrations
{
    public partial class ModificandoEntidadVitaminas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnidadDeMedida",
                table: "Vitaminas",
                newName: "Existencia");

            migrationBuilder.AddColumn<string>(
                name: "UnidadMedida",
                table: "Vitaminas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 1,
                columns: new[] { "Existencia", "UnidadMedida" },
                values: new object[] { 0.0, "Miligramos" });

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 2,
                columns: new[] { "Existencia", "UnidadMedida" },
                values: new object[] { 0.0, "Kilosgramos" });

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 3,
                columns: new[] { "Existencia", "UnidadMedida" },
                values: new object[] { 0.0, "Gramos" });

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 4,
                columns: new[] { "Existencia", "UnidadMedida" },
                values: new object[] { 0.0, "Gramos" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnidadMedida",
                table: "Vitaminas");

            migrationBuilder.RenameColumn(
                name: "Existencia",
                table: "Vitaminas",
                newName: "UnidadDeMedida");

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 1,
                column: "UnidadDeMedida",
                value: 2.5);

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 2,
                column: "UnidadDeMedida",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 3,
                column: "UnidadDeMedida",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "Vitaminas",
                keyColumn: "VitaminaId",
                keyValue: 4,
                column: "UnidadDeMedida",
                value: 3.0);
        }
    }
}
