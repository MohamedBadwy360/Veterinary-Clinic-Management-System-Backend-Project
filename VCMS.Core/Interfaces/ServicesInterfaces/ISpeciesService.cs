namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface ISpeciesService
    {
        Task<Response<SpeciesDto>> GetSpeciesByIdAsync(int id);
        Task<Response<IEnumerable<SpeciesDto>>> GetAllSpeciesAsync();
        Task<Response<SpeciesDto>> CreateSpeciesAsync(SpeciesDto speciesDto);
        Task<Response<SpeciesDto>> UpdateSpeciesByIdAsync(int id, SpeciesDto speciesDto);
        Task<Response<SpeciesDto>> DeleteSpeciesByIdAsync(int id);
    }
}
