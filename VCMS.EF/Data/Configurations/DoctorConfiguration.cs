namespace VCMS.EF.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd();

            builder.Property(d => d.FirstName)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.LastName)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.PhoneNumber)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(d => d.Email)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(d => d.YearGraduated)
                .IsRequired();

            builder.HasMany(d => d.Cases)
                .WithOne(c => c.Doctor)
                .HasForeignKey(c => c.DoctorId)
                .IsRequired();

            builder.HasIndex(d => d.Email, "UIX_Doctors_Email")
                .IsUnique();

            builder.HasData(SeedData.LoadDoctors());

            builder.ToTable("Doctors");
        }
    }
}
