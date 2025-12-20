using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlateformeEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class SeedEvaluations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "DateCreation", "Description", "DureeMinutes", "Titre" },
                values: new object[] { 2, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test de compréhension française", 20, "Évaluation Français" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
