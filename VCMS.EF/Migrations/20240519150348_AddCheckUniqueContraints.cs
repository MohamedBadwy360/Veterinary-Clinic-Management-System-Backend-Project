using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VCMS.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckUniqueContraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VARCHAR",
                table: "Diagnostics",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diagnostics",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "UIX_Species_Name",
                table: "Species",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UIX_Medication_GenericName",
                table: "Medications",
                column: "GenericName",
                unique: true,
                filter: "[GenericName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UIX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UIX_Diagnostics_Name",
                table: "Diagnostics",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UIX_Species_Name",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "UIX_Medication_GenericName",
                table: "Medications");

            migrationBuilder.DropIndex(
                name: "UIX_Doctors_Email",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "UIX_Diagnostics_Name",
                table: "Diagnostics");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Diagnostics",
                newName: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "VARCHAR",
                table: "Diagnostics",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);
        }
    }
}
