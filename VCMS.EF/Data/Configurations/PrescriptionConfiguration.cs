namespace VCMS.EF.Data.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Date)
                .HasColumnType(SqlServerDataTypes.DATE)
                .IsRequired();

            builder.HasOne(p => p.Case)
                .WithOne(c => c.Prescription)
                .HasForeignKey<Prescription>(p => p.CaseId)
                .IsRequired();

            builder.HasMany(p => p.Medications)
                .WithMany(m => m.Prescriptions)
                .UsingEntity<PrescribedMeds>(
                    l => l.HasOne<Medication>(pm => pm.Medication)
                    .WithMany(m => m.PrescribedMeds)
                    .HasForeignKey(pm => pm.MedicationId),

                    r => r.HasOne<Prescription>(pm => pm.Prescription)
                    .WithMany(m => m.PrescribedMeds)
                    .HasForeignKey(pm => pm.PrescriptionId));

            builder.HasData(SeedData.LoadPrescriptions());

            builder.ToTable("Prescriptions");
        }
    }
}
