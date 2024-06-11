namespace VCMS.EF.Repositories
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRespository
    {
        private readonly VCMSDbContext _context;
        public PrescriptionRepository(VCMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetPrescriptionDto>> GetAllPrescriptionsAsync()
        {
            return await _context.Prescriptions
                .Include(p => p.PrescribedMeds)
                .ThenInclude(pm => pm.Medication)
                .Select(p => new GetPrescriptionDto
                {
                    CaseId = p.CaseId,
                    Date = p.Date,
                    PrescribedMedcations = p.PrescribedMeds.Select(pm => new GetPrescribedMedDto
                    {
                        MedicationName = pm.Medication.TradeName,
                        Quantity = pm.Quantity,
                        Price = pm.Price,
                        Frequency = pm.Frequency,
                        TotalPrice = pm.TotalPrice
                    })
                    .ToList()
                })
                .ToListAsync();
        }
    }
}
