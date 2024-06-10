namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface IMedicationsService
    {
        /// <summary>
        /// Retrieves a medication by its unique identifier. 
        /// </summary>
        /// <param name="id">The unique identifier ofthe medication.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{MedicationDto}"/> object which includes the medication details if exists 
        /// along with success status, status code, and message error if an error occurred.</returns>
        Task<Response<MedicationDto>> GetMedicationByIdAsync(int id);

        /// <summary>
        /// Retrieves all medications asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{IEnumerable{MedicationDto}}"/> object which includes the collection 
        /// of medications details if exists along with success status, status code, 
        /// and message error if an error occurred.</returns>
        Task<Response<IEnumerable<MedicationDto>>> GetAllMedicationsAsync();

        /// <summary>
        /// Create a medication asynchronously.
        /// </summary>
        /// <param name="medicationDto">The medication data to be created.</param>
        /// <returns>
        ///  A task that represents the asynchronous operation. The task result contains a 
        /// <see cref="Response{MedicationDto}"/> object which includes the created medication details if successful,
        /// along with success status, status code, and an error message if applicable.
        /// </returns>
        Task<Response<MedicationDto>> CreateMedicationAsync(MedicationDto medicationDto);

        /// <summary>
        /// Updates an existing medication asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the medication to update.</param>
        /// <param name="medicationDto">The medication data with which to update the existing medication.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a 
        /// <see cref="Response{MedicationDto}"/> object which includes the updated medication details if successful,
        /// along with success status, status code, and an error message if applicable.
        /// </returns>
        Task<Response<MedicationDto>> UpdateMedicationAsync(int id, MedicationDto medicationDto);

        /// <summary>
        /// Deletes a medication asynchronously by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the medication to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a 
        /// <see cref="Response{MedicationDto}"/> object which includes the deleted medication details if successful,
        /// along with success status, status code, and an error message if applicable.
        /// </returns>
        Task<Response<MedicationDto>> DeleteMedicationAsync(int id);
    }
}
