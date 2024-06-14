namespace VCMS.Core.Interfaces.DbInterfaces
{
    /// <summary>
    /// Interface for Receipt Repository to implement the specific methods of the Receipt entity.
    /// </summary>
    public interface IReceiptRepository : IBaseRepository<Receipt>
    {
        /// <summary>
        /// Get the total price of the receipt by the prescription id.
        /// </summary>
        /// <param name="prescriptionId">
        /// The prescription id to get the total price of the receipt.
        /// </param>
        /// <returns>
        /// The total price of the receipt.
        /// </returns>
        Task<decimal> GetReceiptTotalPriceByPrescriptionId(int prescriptionId);
    }
}
