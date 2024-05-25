namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface IClientService
    {
        Task<Response<ClientDto>> GetClientByIdAsync(int id);
        Task<Response<IEnumerable<ClientDto>>> GetAllClientAsync();
        Task<Response<ClientDto>> CreateClientAsync(ClientDto clientDto);
        Task<Response<ClientDto>> UpdateClientByIdAsync(int id, ClientDto clientDto);
        Task<Response<ClientDto>> DeleteClientByIdAsync(int id);
    }
}
