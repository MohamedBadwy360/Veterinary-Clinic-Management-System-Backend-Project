namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface IDoctorsService
    {
        Task<Response<DoctorDto>> GetDoctorByIdAsync(int id);
        Task<Response<IEnumerable<DoctorDto>>> GetAllDoctorsAsync();
        Task<Response<DoctorDto>> CreateDoctorAsync(DoctorDto doctorDto);
        Task<Response<DoctorDto>> UpdateDoctorAsync(int id, DoctorDto doctorDto);
        Task<Response<DoctorDto>> DeleteDoctorByIdAsync(int id);
    }
}
