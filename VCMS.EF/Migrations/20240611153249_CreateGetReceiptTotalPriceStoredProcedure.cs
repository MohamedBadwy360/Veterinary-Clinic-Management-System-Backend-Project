using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VCMS.EF.Migrations
{
    /// <inheritdoc />
    public partial class CreateGetReceiptTotalPriceStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.GetReceiptTotalPriceByPrescriptionIdProcedure
                @prescriptionId INT,
                @receiptTotalPrice DECIMAL(8, 2) OUTPUT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT @receiptTotalPrice = SUM(TotalPrice)
                    FROM PrescribedMeds
                    WHERE PrescriptionId = @prescriptionId
                    GROUP BY PrescriptionId;
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetReceiptTotalPriceByPrescriptionIdProcedure");
        }
    }
}
