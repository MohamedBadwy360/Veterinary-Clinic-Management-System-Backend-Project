namespace VCMS.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VCMSDbContext _context;

        public UnitOfWork(VCMSDbContext context)
        {
            _context = context;

            Cases = new CaseRepository(_context);
            Clients = new BaseRepository<Client>(_context);
            Diagnostics = new BaseRepository<Diagnosis>(_context);
            Doctors = new BaseRepository<Doctor>(_context);
            Medications = new BaseRepository<Medication>(_context);
            Patients = new PatientRepository(_context);
            PrescribedMeds = new BaseRepository<PrescribedMeds>(_context);
            Prescriptions = new BaseRepository<Prescription>(_context);
            Receipts = new BaseRepository<Receipt>(_context);
            Species = new BaseRepository<Species>(_context);
        }

        public ICaseRepository Cases { get; private set; }
        public IBaseRepository<Client> Clients { get; private set; }
        public IBaseRepository<Diagnosis> Diagnostics { get; private set; }
        public IBaseRepository<Doctor> Doctors { get; private set; }
        public IBaseRepository<Medication> Medications { get; private set; }
        public IPatientRepository Patients { get; private set; }
        public IBaseRepository<PrescribedMeds> PrescribedMeds { get; private set; }
        public IBaseRepository<Prescription> Prescriptions { get; private set; }
        public IBaseRepository<Receipt> Receipts { get; private set; }
        public IBaseRepository<Species> Species { get; private set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
