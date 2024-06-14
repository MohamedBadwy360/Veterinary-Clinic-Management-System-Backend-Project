namespace VCMS.Core.Interfaces.DbInterfaces
{
    /// <summary>
    /// Prescription Repository Interface to define specific methods for the Prescription entity. 
    /// </summary>
    public interface IPrescriptionRespository : IBaseRepository<Prescription>
    {
        /// <summary>
        /// Get all prescriptions asynchronously.
        /// </summary>
        /// <returns>
        /// A collection of prescriptions.
        /// </returns>
        Task<IEnumerable<GetPrescriptionDto>> GetAllPrescriptionsAsync();
    }
}
