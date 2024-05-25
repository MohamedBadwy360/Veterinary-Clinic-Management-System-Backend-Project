namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface IDiagnosisService
    {
        Task<Response<DiagnosisDto>> GetDiagnosisByIdAsync(int id);
        Task<Response<IEnumerable<DiagnosisDto>>> GetAllDiagnosisAsync();
        Task<Response<DiagnosisDto>> CreateDiagnosisAsync(DiagnosisDto diagnosisDto);
        Task<Response<DiagnosisDto>> UpdateDiagnosisByIdAsync(int id, DiagnosisDto diagnosisDto);
        Task<Response<DiagnosisDto>> DeleteDiagnosisByIdAsync(int id);
    }
}
