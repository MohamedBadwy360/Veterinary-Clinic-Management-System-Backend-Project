namespace VCMS.EF.Data
{
    public class VCMSDbContext : DbContext
    {
        public VCMSDbContext(DbContextOptions<VCMSDbContext> options)
            : base(options) { }

        public VCMSDbContext()
        {
            
        }

        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Diagnosis> Diagnostics { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PrescribedMeds> PrescribedMeds { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Species> Species { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpeciesConfiguration).Assembly);
        }
    }
}
