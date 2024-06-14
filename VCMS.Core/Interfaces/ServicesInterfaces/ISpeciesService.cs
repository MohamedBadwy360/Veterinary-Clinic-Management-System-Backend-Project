namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    /// <summary>
    /// Interface for Species Service to handle Species related business logic.
    /// </summary>
    public interface ISpeciesService
    {
        /// <summary>
        /// Retrieves a species by Id. 
        /// </summary>
        /// <param name="id">The unique identifier ofthe species.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{SpeciesDto}"/> object which includes the species details if exists 
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<SpeciesDto>> GetSpeciesByIdAsync(int id);

        /// <summary>
        /// Retrieves all species asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{IEnumerable{SpeciesDto}}"/> object which includes the collection
        /// of species details if exists along with success status, status code, and message error if an 
        /// error occurred. 
        /// </returns>
        Task<Response<IEnumerable<SpeciesDto>>> GetAllSpeciesAsync();

        /// <summary>
        /// Create a species asynchronously.
        /// </summary>
        /// <param name="speciesDto">The species data to be created.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a
        /// <see cref="Response{SpeciesDto}"/> object which includes the created species details if successful,
        /// along with success status, status code, and an error message if applicable.
        /// </returns>
        Task<Response<SpeciesDto>> CreateSpeciesAsync(SpeciesDto speciesDto);

        /// <summary>
        /// Updates an existing species asynchronously.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the species to update.
        /// </param>
        /// <param name="speciesDto">
        /// The species data with which to update the existing species.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a
        /// <see cref="Response{SpeciesDto}"/> object which includes the updated species details if successful,
        /// along with success status, status code, and an error message if applicable.
        /// </returns>
        Task<Response<SpeciesDto>> UpdateSpeciesByIdAsync(int id, SpeciesDto speciesDto);

        /// <summary>
        /// Deletes a species asynchronously by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the species to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a
        /// <see cref="Response{SpeciesDto}"/> object which includes the deleted species details if successful,
        /// along with success status, status code, and an error message if applicable.
        /// </returns>
        Task<Response<SpeciesDto>> DeleteSpeciesByIdAsync(int id);
    }
}
