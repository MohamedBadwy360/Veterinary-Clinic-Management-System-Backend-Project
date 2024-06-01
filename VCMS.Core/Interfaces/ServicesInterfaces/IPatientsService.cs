namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface IPatientsService
    {
        Task<Response<GetPatientDto>> GetPatientByIdAsync(int id);
        Task<Response<IEnumerable<GetPatientDto>>> GetAllPatientsAsync();
        Task<Response<CreatePatientDto>> CreatePatientAsync(CreatePatientDto createPatientDto);
        Task<Response<UpdatePatientDto>> UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto);
        Task<Response<DeletePatientDto>> DeletePatientAsync(int id);
    }
}
