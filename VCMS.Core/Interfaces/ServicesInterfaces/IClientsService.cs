namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    /// <summary>
    /// Clients service interface for clients service define the methods that will be implemented in the service
    /// to handle the clients-related business logic.
    /// </summary>
    public interface IClientsService
    {
        /// <summary>
        /// Get client by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the client to get.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <see cref="Response{ClientDto}"/> object which includes the client details if exists 
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<ClientDto>> GetClientByIdAsync(int id);

        /// <summary>
        /// Get all clients asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{IEnumerable{ClientDto}}"/> object which includes the list of clients
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<IEnumerable<ClientDto>>> GetAllClientAsync();

        /// <summary>
        /// Create a new client asynchronously.
        /// </summary>
        /// <param name="clientDto">
        /// The client data transfer object to create.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{ClientDto}"/> object which includes the created client details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<ClientDto>> CreateClientAsync(ClientDto clientDto);

        /// <summary>
        /// Update client by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the client to update.
        /// </param>
        /// <param name="clientDto">
        /// The client data transfer object to update.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{ClientDto}"/> object which includes the updated client details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<ClientDto>> UpdateClientByIdAsync(int id, ClientDto clientDto);

        /// <summary>
        /// Delete client by id asynchronously.
        /// </summary>
        /// <param name="id">
        /// The id of the client to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// <see cref="Response{ClientDto}"/> object which includes the deleted client details
        /// along with success status, status code, and message error if an error occurred.
        /// </returns>
        Task<Response<ClientDto>> DeleteClientByIdAsync(int id);
    }
}
