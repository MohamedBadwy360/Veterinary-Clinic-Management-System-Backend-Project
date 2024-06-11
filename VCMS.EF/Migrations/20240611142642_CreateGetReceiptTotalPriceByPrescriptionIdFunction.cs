using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VCMS.EF.Migrations
{
    /// <inheritdoc />
    public partial class CreateGetReceiptTotalPriceByPrescriptionIdFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create function [dbo].[GetReceiptTotalPriceByPrescriptionId](@prescriptionId int)
                returns decimal(8, 2)
                as
                begin 
	                declare @receiptTotalPrice decimal(8, 2);

	                select @receiptTotalPrice = sum(TotalPrice)
	                from PrescribedMeds
	                where PrescriptionId = @prescriptionId
	                group by PrescriptionId;

	                return @receiptTotalPrice;
                end                       
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop function [dbo].[GetReceiptTotalPriceByPrescriptionId]");
        }
    }
}
