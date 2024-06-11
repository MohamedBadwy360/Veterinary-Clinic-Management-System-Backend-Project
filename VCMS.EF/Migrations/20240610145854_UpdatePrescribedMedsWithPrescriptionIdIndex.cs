using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VCMS.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrescribedMedsWithPrescriptionIdIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMeds_PrescriptionId",
                table: "PrescribedMeds",
                column: "PrescriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PrescribedMeds_PrescriptionId",
                table: "PrescribedMeds");

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Category", "CostPricePerItem", "ExpirationDate", "GenericName", "SalePricePerItem", "TradeName", "Unit", "UnitInStock" },
                values: new object[] { 10, "Antibiotic", 10m, new DateOnly(2028, 3, 1), "Oxytetracycline 20%", 15m, "Antibiotic", "20 gm", 30 });
        }
    }
}
