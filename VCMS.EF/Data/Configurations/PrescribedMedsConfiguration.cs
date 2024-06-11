namespace VCMS.EF.Data.Configurations
{
    public class PrescribedMedsConfiguration : IEntityTypeConfiguration<PrescribedMeds>
    {
        public void Configure(EntityTypeBuilder<PrescribedMeds> builder)
        {
            builder.HasKey(pm => new { pm.PrescriptionId, pm.MedicationId });

            builder.Property(pm => pm.Quantity)
                .IsRequired();

            builder.Property(pm => pm.Price)
                .HasPrecision(8, 2)
                .IsRequired();

            builder.Property(pm => pm.TotalPrice)
                .HasPrecision(8, 2)
                .HasComputedColumnSql("Quantity * Price")
                .IsRequired();

            builder.Property(pm => pm.Frequency)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(pm => new { pm.PrescriptionId, pm.MedicationId });
            builder.HasIndex(pm => pm.PrescriptionId);

            builder.HasData(SeedData.LoadPrescribedMeds());

            builder.ToTable("PrescribedMeds");
        }
    }
}
