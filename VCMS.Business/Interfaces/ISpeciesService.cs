namespace VCMS.Business.Interfaces
{
    public interface ISpeciesService
    {
        Task<Response<SpeciesDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<SpeciesDto>>> GetAllAsync();
        Task<Response<SpeciesDto>> CreateAsync(SpeciesDto speciesDto);
        Task<Response<SpeciesDto>> UpdateAsync(int id, SpeciesDto speciesDto);
    }
}
