namespace VCMS.Core.Interfaces.DbInterfaces
{
    public interface ICaseRepository : IBaseRepository<Case>
    {
        /// <summary>
        /// Retrieve all cases with client name, species name, diagnosis name, and doctor name from database.
        /// This is a more optimized way to retrieve all cases to retrive only the needed columns from database.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GetCaseDto>> GetAllCasesWithClientNameSpeciesNameDiagnosisNameDoctorName();
    }
}
