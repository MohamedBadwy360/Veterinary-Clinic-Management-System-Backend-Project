namespace VCMS.Core.Interfaces.DbInterfaces
{
    public interface IReceiptRepository : IBaseRepository<Receipt>
    {
        Task<decimal> GetReceiptTotalPriceByPrescriptionId(int prescriptionId);
    }
}
