namespace VCMS.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VCMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JwtOptions> _options;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ICaseRepository _cases;
        private IBaseRepository<Client> _clients;
        private IBaseRepository<Diagnosis> _diagnostics;
        private IBaseRepository<Doctor> _doctors;
        private IBaseRepository<Medication> _medications;
        private IPatientRepository _patients;
        private IBaseRepository<PrescribedMeds> _prescribedMeds;
        private IPrescriptionRespository _prescriptions;
        private IReceiptRepository _receipts;
        private IBaseRepository<Species> _species;
        private IAuthRepository _authentication;

        public UnitOfWork(VCMSDbContext context, UserManager<ApplicationUser> userManager,
            IOptions<JwtOptions> options, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _options = options;
            _roleManager = roleManager;
        }

        public ICaseRepository Cases
        {
            get
            {
                _cases ??= new CaseRepository(_context);
                return _cases;
            }
        }
        public IBaseRepository<Client> Clients
        {
            get
            {
                _clients ??= new BaseRepository<Client>(_context);
                return _clients;
            }
        }
        public IBaseRepository<Diagnosis> Diagnostics
        {
            get
            {
                _diagnostics ??= new BaseRepository<Diagnosis>(_context);
                return _diagnostics;
            }
        }
        public IBaseRepository<Doctor> Doctors
        {
            get
            {
                _doctors ??= new BaseRepository<Doctor>(_context);
                return _doctors;
            }
        }
        public IBaseRepository<Medication> Medications
        {
            get
            {
                _medications ??= new BaseRepository<Medication>(_context);
                return _medications;
            }
        }
        public IPatientRepository Patients
        {
            get
            {
                _patients ??= new PatientRepository(_context);
                return _patients;
            }
        }
        public IBaseRepository<PrescribedMeds> PrescribedMeds
        {
            get
            {
                _prescribedMeds ??= new BaseRepository<PrescribedMeds>(_context);
                return _prescribedMeds;
            }
        }
        public IPrescriptionRespository Prescriptions
        {
            get
            {
                _prescriptions ??= new PrescriptionRepository(_context);
                return _prescriptions;
            }
        }
        public IReceiptRepository Receipts
        {
            get
            {
                _receipts ??= new ReceiptRepository(_context);
                return _receipts;
            }
        }
        public IBaseRepository<Species> Species
        {
            get
            {
                _species ??= new BaseRepository<Species>(_context);
                return _species;
            }
        }
        public IAuthRepository Authentication
        {
            get
            {
                _authentication ??= new AuthRepository(_userManager, _roleManager, _options);
                return _authentication;
            }
        }

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
