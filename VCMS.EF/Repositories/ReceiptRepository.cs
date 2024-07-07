namespace VCMS.EF.Repositories
{
    public class ReceiptRepository : BaseRepository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(VCMSDbContext context) : base(context) { }
        //public async Task<decimal> GetReceiptTotalPriceByPrescriptionId(int prescriptionId)
        //{
        //    return await _context.Receipts.
        //        FromSql($"select dbo.GetReceiptTotalPriceByPrescriptionId({prescriptionId}) as TotalPrice")
        //        .Select(r => r.TotalPrice)
        //        .FirstOrDefaultAsync();
        //}

        public async Task<decimal> GetReceiptTotalPriceByPrescriptionId(int prescriptionId)
        {
            return await _context.GetReceiptTotalPriceByPrescriptionId(prescriptionId);
        }
    }
}
