namespace VCMS.EF.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Sex)
                .HasColumnType(SqlServerDataTypes.TINYINT)
                .IsRequired();

            builder.Property(p => p.Age)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(25)
                .IsRequired();

            builder.HasMany(p => p.Cases)
                .WithOne(c => c.Patient)
                .HasForeignKey(c => c.PatientId)
                .IsRequired();

            builder.HasData(SeedData.LoadPatients());

            builder.ToTable("Patients");
        }
    }
}
