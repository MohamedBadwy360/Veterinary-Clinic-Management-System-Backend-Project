namespace VCMS.Core.Interfaces.DbInterfaces
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<IEnumerable<GetPatientDto>> GetAllPatientsWithClientNameAndSpeciesName();
    }
}
