namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    /// <summary>
    /// Interface for the PrescriptionsService that contains the business logic for the Prescriptions.
    /// </summary>
    public interface IPrescriptionsService
    {
        /// <summary>
        /// Get a prescription by its id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the prescription to get.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{GetPrescriptionDto}"/> object which includes the prescription details if exists 
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<GetPrescriptionDto>> GetPrescriptionByIdAsync(int id);

        /// <summary>
        /// Get all prescriptions asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{IEnumerable{GetPrescriptionDto}}"/> object which includes the list of prescriptions
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<IEnumerable<GetPrescriptionDto>>> GetAllPrescriptionsAsync();

        /// <summary>
        /// Create a prescription asynchronously.
        /// </summary>
        /// <param name="createPrescriptionDto">
        /// The prescription details to create.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{CreatePrescriptionDto}"/> object which includes the created prescription details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<CreatePrescriptionDto>> CreatePrescriptionAsync(CreatePrescriptionDto createPrescriptionDto);

        /// <summary>
        /// Update a prescription asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the prescription to update.
        /// </param>
        /// <param name="updatePrescriptionDto">
        /// The prescription details to update.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{UpdatePrescriptionDto}"/> object which includes the updated prescription details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<UpdatePrescriptionDto>> UpdatePrescriptionAsync(int id, UpdatePrescriptionDto updatePrescriptionDto);

        /// <summary>
        /// Delete a prescription asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the prescription to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DeletePrescriptionDto}"/> object which includes the deleted prescription details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DeletePrescriptionDto>> DeletePrescriptionAsync(int id);

        /// <summary>
        /// Add a medication to a prescription asynchronously.
        /// </summary>
        /// <param name="prescriptionId">
        /// The id of the prescription to add the medication to.
        /// </param>
        /// <param name="medicationId">
        /// The id of the medication to add to the prescription.
        /// </param>
        /// <param name="quantity">
        /// The quantity of the medication to add to the prescription.
        /// </param>
        /// <param name="frequency">
        /// The frequency of the medication to add to the prescription.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{PrescribedMedsDto}"/> object which includes the prescribed medication details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<PrescribedMedsDto>> AddMedicationToPrescription(int prescriptionId,
            int medicationId, int quantity, string frequency);

        /// <summary>
        /// Delete a medication from a prescription asynchronously.
        /// </summary>
        /// <param name="prescriptionId">
        /// The id of the prescription to delete the medication from.
        /// </param>
        /// <param name="medicationId">
        /// The id of the medication to delete from the prescription.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{PrescribedMedsDto}"/> object which includes the prescribed medication details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<PrescribedMedsDto>> DeleteMedicationFromPrescription(int prescriptionId,
            int medicationId);
    }
}
