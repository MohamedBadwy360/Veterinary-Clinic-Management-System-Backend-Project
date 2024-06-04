namespace VCMS.Core.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICaseRepository Cases { get; }
        IBaseRepository<Client> Clients { get; }
        IBaseRepository<Diagnosis> Diagnostics { get; }
        IBaseRepository<Doctor> Doctors { get; }
        IBaseRepository<Medication> Medications { get; }
        IPatientRepository Patients { get; }
        IBaseRepository<PrescribedMeds> PrescribedMeds { get; }
        IBaseRepository<Prescription> Prescriptions { get; }
        IBaseRepository<Receipt> Receipts { get; }
        IBaseRepository<Species> Species { get; }

        Task<int> CommitAsync();
    }
}
