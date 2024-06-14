namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    /// <summary>
    /// Cases service interface for cases service define the methods that will be implemented in the service
    /// to handle the cases-related business logic.
    /// </summary>
    public interface ICasesService
    {
        /// <summary>
        /// Get case by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the case to get.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{GetCaseDto}"/> object which includes the case details if exists 
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<GetCaseDto>> GetCaseByIdAsync(int id);

        /// <summary>
        /// Get all cases asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{IEnumerable{GetCaseDto}}"/> object which includes the list of cases
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<IEnumerable<GetCaseDto>>> GetAllCasesAsync();

        /// <summary>
        /// Create case asynchronously.
        /// </summary>
        /// <param name="createCaseDto">
        /// The case details to create.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{CreateCaseDto}"/> object which includes the created case details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<CreateCaseDto>> CreateCaseAsync(CreateCaseDto createCaseDto);

        /// <summary>
        /// Update case asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the case to update.
        /// </param>
        /// <param name="updateCaseDto">
        /// The case details to update.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{UpdateCaseDto}"/> object which includes the updated case details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<UpdateCaseDto>> UpdateCaseAsync(int id, UpdateCaseDto updateCaseDto);

        /// <summary>
        /// Delete case asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the case to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DeleteCaseDto}"/> object which includes the deleted case details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DeleteCaseDto>> DeleteCaseAsync(int id);
    }
}
