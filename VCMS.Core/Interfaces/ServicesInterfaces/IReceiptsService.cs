namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    /// <summary>
    /// Interface for ReceiptsService to handle the business logic related to Receipts.
    /// </summary>
    public interface IReceiptsService
    {
        /// <summary>
        /// Get a receipt by its id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the receipt to get.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{GetReceiptDto}"/> object which includes the receipt details if exists 
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<GetReceiptDto>> GetReceiptByIdAsync(int id);

        /// <summary>
        /// Get all receipts asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{IEnumerable{GetReceiptDto}}"/> object which includes the list of receipts
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<IEnumerable<GetReceiptDto>>> GetAllReceiptsAsync();

        /// <summary>
        /// Create a new receipt asynchronously.
        /// </summary>
        /// <param name="createReceiptDto">
        /// The receipt details to create.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{CreateReceiptDto}"/> object which includes the created receipt details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<CreateReceiptDto>> CreateReceiptAsync(CreateReceiptDto createReceiptDto);

        /// <summary>
        /// Update a receipt by its id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the receipt to update.
        /// </param>
        /// <param name="updateReceiptDto">
        /// The receipt details to update.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{UpdateReceiptDto}"/> object which includes the updated receipt details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<UpdateReceiptDto>> UpdateReceiptAsync(int id, UpdateReceiptDto updateReceiptDto);

        /// <summary>
        /// Delete a receipt by its id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the receipt to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DeleteReceiptDto}"/> object which includes the deleted receipt details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DeleteReceiptDto>> DeleteReceiptAsync(int id);
    }
}
