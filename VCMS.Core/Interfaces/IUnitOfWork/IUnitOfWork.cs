namespace VCMS.Core.Interfaces.IUnitOfWork
{
    /// <summary>
    /// Interface for Unit of Work pattern to handle multiple repositories in a single transaction scope.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Repository for Cases.
        /// </summary>
        ICaseRepository Cases { get; }

        /// <summary>
        /// Repository for Clients.
        /// </summary>
        IBaseRepository<Client> Clients { get; }

        /// <summary>
        /// Repository for Diagnostics.
        /// </summary>
        IBaseRepository<Diagnosis> Diagnostics { get; }

        /// <summary>
        /// Repository for Doctors.
        /// </summary>
        IBaseRepository<Doctor> Doctors { get; }

        /// <summary>
        /// Repository for Medications.
        /// </summary>
        IBaseRepository<Medication> Medications { get; }

        /// <summary>
        /// Repository for Patients.
        /// </summary>
        IPatientRepository Patients { get; }

        /// <summary>
        /// Repository for PrescribedMeds.
        /// </summary>
        IBaseRepository<PrescribedMeds> PrescribedMeds { get; }

        /// <summary>
        /// Repository for Prescriptions.
        /// </summary>
        IPrescriptionRespository Prescriptions { get; }

        /// <summary>
        /// Repository for Receipts.
        /// </summary>
        IReceiptRepository Receipts { get; }

        /// <summary>
        /// Repository for Species.
        /// </summary>
        IBaseRepository<Species> Species { get; }
        IAuthRepository Authentication { get; }

        /// <summary>
        /// Commit changes to the database asynchronously.
        /// </summary>
        /// <returns>
        /// The number of affected rows.
        /// </returns>
        Task<int> CommitAsync();
    }
}
