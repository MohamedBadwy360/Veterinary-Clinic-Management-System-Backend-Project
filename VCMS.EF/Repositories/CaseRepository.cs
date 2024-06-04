namespace VCMS.EF.Repositories
{
    public class CaseRepository : BaseRepository<Case>, ICaseRepository
    {
        private readonly VCMSDbContext _context;

        public CaseRepository(VCMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCaseDto>> GetAllCasesWithClientNameSpeciesNameDiagnosisNameDoctorName()
        {
            return await _context.Cases
                .Include(c => c.Patient.Client)
                .Include(c => c.Patient.Species)
                .Include(c => c.Diagnosis)
                .Include(c => c.Doctor)
                .Select(c => new GetCaseDto
                {
                    ClientName = $"{c.Patient.Client.FirstName} {c.Patient.Client.LastName}",
                    SpeciesName = c.Patient.Species.Name,
                    DiagnosisName = c.Diagnosis.Name,
                    DoctorName = $"{c.Doctor.FirstName} {c.Doctor.LastName}",
                    CaseType = c.CaseType.ToString(),
                    Status = c.Status.ToString(),
                    Date = c.Date,
                    Notes = c.Notes
                })
                .ToListAsync();
        }
    }
}
