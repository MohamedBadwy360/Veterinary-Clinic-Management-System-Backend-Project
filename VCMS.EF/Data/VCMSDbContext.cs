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

        /// <summary>
        /// Get receipt's total price by prescriptionId
        /// </summary>
        /// <param name="prescriptionId">The Id of the prescription</param>
        /// <returns>Total price of the prescription</returns>
        public async Task<decimal> GetReceiptTotalPriceByPrescriptionId(int prescriptionId)
        {
            SqlParameter prescriptionIdParamter = new SqlParameter
            {
                ParameterName = "@prescriptionId",
                SqlDbType = SqlDbType.Int,
                Value = prescriptionId
            };

            SqlParameter receiptTotalPriceParam = new SqlParameter
            {
                ParameterName = "@receiptTotalPrice",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Output,
                Precision = 8,
                Scale = 2
            };

            await Database.ExecuteSqlRawAsync(
                "EXEC dbo.GetReceiptTotalPriceByPrescriptionIdProcedure @prescriptionId, @receiptTotalPrice OUTPUT",
                prescriptionIdParamter,
                receiptTotalPriceParam);

            return (decimal)receiptTotalPriceParam.Value;
        }

        //[DbFunction(Name = "GetReceiptTotalPriceByPrescriptionId", Schema = "dbo")]
        //public static decimal GetReceiptTotalPriceByPrescriptionId(int prescriptionId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
