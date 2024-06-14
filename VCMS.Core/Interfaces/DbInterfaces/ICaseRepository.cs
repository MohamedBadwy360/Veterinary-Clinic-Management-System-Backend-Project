namespace VCMS.Core.Interfaces.DbInterfaces
{
    /// <summary>
    /// Interface for Case Repository to implement specific methods for Case entity.
    /// </summary>
    public interface ICaseRepository : IBaseRepository<Case>
    {
        /// <summary>
        /// Retrieve all cases with client name, species name, diagnosis name, and doctor name from database.
        /// This is a more optimized way to retrieve all cases to retrive only the needed columns from database.
        /// </summary>
        /// <returns>
        /// A list of GetCaseDto objects containing the case information with client name, species name, 
        /// diagnosis name, and doctor name.
        /// </returns>
        Task<IEnumerable<GetCaseDto>> GetAllCasesWithClientNameSpeciesNameDiagnosisNameDoctorName();
    }
}
