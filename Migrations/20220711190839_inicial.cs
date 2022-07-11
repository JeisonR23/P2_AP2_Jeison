using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jeison_Par2_AP1.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verduras",
                columns: table => new
                {
                    VerduraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verduras", x => x.VerduraId);
                });

            migrationBuilder.CreateTable(
                name: "Vitaminas",
                columns: table => new
                {
                    VitaminaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    UnidadDeMedida = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitaminas", x => x.VitaminaId);
                });

            migrationBuilder.CreateTable(
                name: "VerdurasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VerduraId = table.Column<int>(type: "INTEGER", nullable: false),
                    VitaminaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerdurasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerdurasDetalle_Verduras_VerduraId",
                        column: x => x.VerduraId,
                        principalTable: "Verduras",
                        principalColumn: "VerduraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Descripcion", "UnidadDeMedida" },
                values: new object[] { 1, "Vitamina B2", 2.5 });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Descripcion", "UnidadDeMedida" },
                values: new object[] { 2, "Vitamina C", 2.0 });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Descripcion", "UnidadDeMedida" },
                values: new object[] { 3, "Vitamina A", 2.0 });

            migrationBuilder.InsertData(
                table: "Vitaminas",
                columns: new[] { "VitaminaId", "Descripcion", "UnidadDeMedida" },
                values: new object[] { 4, "Vitamina D", 3.0 });

            migrationBuilder.CreateIndex(
                name: "IX_VerdurasDetalle_VerduraId",
                table: "VerdurasDetalle",
                column: "VerduraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerdurasDetalle");

            migrationBuilder.DropTable(
                name: "Vitaminas");

            migrationBuilder.DropTable(
                name: "Verduras");
        }
    }
}
