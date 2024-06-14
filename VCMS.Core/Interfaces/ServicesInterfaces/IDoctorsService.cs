namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    /// <summary>
    /// Doctors service interface for doctors service define the methods that will be implemented in the service
    /// to handle the doctors-related business logic.
    /// </summary>
    public interface IDoctorsService
    {
        /// <summary>
        /// Get doctor by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the doctor to get.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{DoctorDto}"/> object which includes the doctor details if exists 
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DoctorDto>> GetDoctorByIdAsync(int id);

        /// <summary>
        /// Get all doctors asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{IEnumerable{DoctorDto}}"/> object which includes the list of doctors
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<IEnumerable<DoctorDto>>> GetAllDoctorsAsync();

        /// <summary>
        /// Create a new doctor asynchronously.
        /// </summary>
        /// <param name="doctorDto">
        /// The doctor data to create.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DoctorDto}"/> object which includes the created doctor details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DoctorDto>> CreateDoctorAsync(DoctorDto doctorDto);

        /// <summary>
        /// Update doctor by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the doctor to update.
        /// </param>
        /// <param name="doctorDto">
        /// The doctor data to update.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DoctorDto}"/> object which includes the updated doctor details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DoctorDto>> UpdateDoctorAsync(int id, DoctorDto doctorDto);

        /// <summary>
        /// Delete doctor by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the doctor to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{DoctorDto}"/> object which includes the deleted doctor details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<DoctorDto>> DeleteDoctorByIdAsync(int id);
    }
}
