using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VCMS.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Cases ADD CONSTRAINT CHK_Status CHECK(Status IN (0, 1))");
            migrationBuilder.Sql("ALTER TABLE Cases ADD CONSTRAINT CHK_CaseType CHECK(CaseType IN (0, 1))");

            migrationBuilder.Sql("ALTER TABLE Doctors ADD CONSTRAINT CHK_YearGraduated CHECK(YearGraduated >= 1990 AND YearGraduated <= 2023)");

            migrationBuilder.Sql("ALTER TABLE Medications ADD CONSTRAINT CHK_UnitInStock CHECK(UnitInStock >= 0)");
            migrationBuilder.Sql("ALTER TABLE Medications ADD CONSTRAINT CHK_CostPricePerItem CHECK(CostPricePerItem > 0)");
            migrationBuilder.Sql("ALTER TABLE Medications ADD CONSTRAINT CHK_SalePricePerItem CHECK(SalePricePerItem > 0)");

            migrationBuilder.Sql("ALTER TABLE Patients ADD CONSTRAINT CHK_Count CHECK(Count > 0)");
            migrationBuilder.Sql("ALTER TABLE Patients ADD CONSTRAINT CHK_Sex CHECK(Sex IN (0, 1))");

            migrationBuilder.Sql("ALTER TABLE PrescribedMeds ADD CONSTRAINT CHK_Quantity CHECK(Quantity > 0)");
            migrationBuilder.Sql("ALTER TABLE PrescribedMeds ADD CONSTRAINT CHK_Price CHECK(Price > 0)");

            migrationBuilder.Sql("ALTER TABLE Receipts ADD CONSTRAINT CHK_TotalPrice CHECK(TotalPrice > 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Cases DROP CONSTRAINT CHK_Status");
            migrationBuilder.Sql("ALTER TABLE Cases DROP CONSTRAINT CHK_CaseType");

            migrationBuilder.Sql("ALTER TABLE Doctors DROP CONSTRAINT CHK_YearGraduated");

            migrationBuilder.Sql("ALTER TABLE Medications DROP CONSTRAINT CHK_UnitInStock");
            migrationBuilder.Sql("ALTER TABLE Medications DROP CONSTRAINT CHK_CostPricePerItem");
            migrationBuilder.Sql("ALTER TABLE Medications DROP CONSTRAINT CHK_SalePricePerItem");

            migrationBuilder.Sql("ALTER TABLE Patients DROP CONSTRAINT CHK_Count");
            migrationBuilder.Sql("ALTER TABLE Patients DROP CONSTRAINT CHK_Sex");

            migrationBuilder.Sql("ALTER TABLE PrescribedMeds DROP CONSTRAINT CHK_Quantity");
            migrationBuilder.Sql("ALTER TABLE PrescribedMeds DROP CONSTRAINT CHK_Price");

            migrationBuilder.Sql("ALTER TABLE Receipts DROP CONSTRAINT CHK_TotalPrice");
        }
    }
}
