namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface ICasesService
    {
        Task<Response<GetCaseDto>> GetCaseByIdAsync(int id);
        Task<Response<IEnumerable<GetCaseDto>>> GetAllCasesAsync();
        Task<Response<CreateCaseDto>> CreateCaseAsync(CreateCaseDto createCaseDto);
        Task<Response<UpdateCaseDto>> UpdateCaseAsync(int id, UpdateCaseDto updateCaseDto);
        Task<Response<DeleteCaseDto>> DeleteCaseAsync(int id);
    }
}
