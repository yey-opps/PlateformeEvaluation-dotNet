using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlateformeEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class AddEval2Eval3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "DateCreation", "Description", "DureeMinutes", "Titre" },
                values: new object[] { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business communication vocabulary and situational understanding", 20, "English - Corporate Communication Test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluations",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
