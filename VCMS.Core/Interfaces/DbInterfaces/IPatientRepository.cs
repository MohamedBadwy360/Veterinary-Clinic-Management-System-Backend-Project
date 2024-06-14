namespace VCMS.Core.Interfaces.DbInterfaces
{
    /// <summary>
    /// Interface for the Patient Repository to implement specific methods for the Patient entity.
    /// </summary>
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        /// <summary>
        /// Get all patients with their client name and species name.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="GetPatientDto"/> objects.
        /// </returns>
        Task<IEnumerable<GetPatientDto>> GetAllPatientsWithClientNameAndSpeciesName();
    }
}
