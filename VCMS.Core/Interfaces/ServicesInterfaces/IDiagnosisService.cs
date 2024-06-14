namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    /// <summary>
    /// Diagnosis service interface for diagnosis service define the methods that will be implemented in the service
    /// to handle the diagnosis-related business logic.
    /// </summary>
    public interface IDiagnosisService
    {
        /// <summary>
        /// Get diagnosis by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the diagnosis to get.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{DiagnosisDto}"/> object which includes the diagnosis details if exists 
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DiagnosisDto>> GetDiagnosisByIdAsync(int id);

        /// <summary>
        /// Get all diagnosis asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{IEnumerable{DiagnosisDto}}"/> object which includes the list of diagnosis
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<IEnumerable<DiagnosisDto>>> GetAllDiagnosisAsync();

        /// <summary>
        /// Create diagnosis asynchronously.
        /// </summary>
        /// <param name="diagnosisDto">
        /// The diagnosis details to create.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DiagnosisDto}"/> object which includes the created diagnosis details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DiagnosisDto>> CreateDiagnosisAsync(DiagnosisDto diagnosisDto);

        /// <summary>
        /// Update diagnosis by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the diagnosis to update.
        /// </param>
        /// <param name="diagnosisDto">
        /// The diagnosis details to update.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DiagnosisDto}"/> object which includes the updated diagnosis details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DiagnosisDto>> UpdateDiagnosisByIdAsync(int id, DiagnosisDto diagnosisDto);

        /// <summary>
        /// Delete diagnosis by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the diagnosis to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DiagnosisDto}"/> object which includes the deleted diagnosis details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DiagnosisDto>> DeleteDiagnosisByIdAsync(int id);
    }
}
