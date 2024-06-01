namespace VCMS.EF.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly VCMSDbContext _context;

        public PatientRepository(VCMSDbContext context) : base(context) 
        {
            _context = context;
        }

        // better in performance because this select only necessary columns
        public async Task<IEnumerable<GetPatientDto>> GetAllPatientsWithClientNameAndSpeciesName()
        {
            return await _context.Patients
                .Include(p => p.Client)
                .Include(p => p.Species)
                .Select(p => new GetPatientDto
                {
                    ClientName = (p.Client != null) ? $"{p.Client.FirstName} {p.Client.LastName}" : null,
                    SpeciesName = (p.Species != null) ? p.Species.Name : null,
                    Count = p.Count,
                    Sex = p.Sex,
                    Age = p.Age
                })
                .ToListAsync();
        }
    }
}
