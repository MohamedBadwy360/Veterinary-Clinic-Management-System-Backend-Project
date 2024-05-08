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
                .HasColumnType("DATE")
                .IsRequired();

            builder.HasOne(p => p.Case)
                .WithOne(c => c.Prescription)
                .HasForeignKey<Prescription>(p => p.CaseId)
                .IsRequired();

            builder.ToTable("Prescriptions");
        }
    }
}
