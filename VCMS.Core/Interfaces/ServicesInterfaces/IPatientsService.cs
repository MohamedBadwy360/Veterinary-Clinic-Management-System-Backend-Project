namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    /// <summary>
    /// Patients service interface to define the methods that will be implemented in the service
    /// to handle the patients-related business logic.
    /// </summary>
    public interface IPatientsService
    {
        /// <summary>
        /// Get a patient by its id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the patient to get.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{GetPatientDto}"/> object which includes the patient details if exists 
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<GetPatientDto>> GetPatientByIdAsync(int id);

        /// <summary>
        /// Get all patients asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{IEnumerable{GetPatientDto}}"/> object which includes the list of patients
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<IEnumerable<GetPatientDto>>> GetAllPatientsAsync();

        /// <summary>
        /// Create a new patient asynchronously.
        /// </summary>
        /// <param name="createPatientDto">
        /// The patient details to create.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{CreatePatientDto}"/> object which includes the created patient details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<CreatePatientDto>> CreatePatientAsync(CreatePatientDto createPatientDto);

        /// <summary>
        /// Update a patient by its id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the patient to update.
        /// </param>
        /// <param name="updatePatientDto">
        /// The patient details to update.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{UpdatePatientDto}"/> object which includes the updated patient details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<UpdatePatientDto>> UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto);

        /// <summary>
        /// Delete a patient by its id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the patient to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DeletePatientDto}"/> object which includes the deleted patient details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DeletePatientDto>> DeletePatientAsync(int id);
    }
}
