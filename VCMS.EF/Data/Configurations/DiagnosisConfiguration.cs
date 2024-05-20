namespace VCMS.EF.Data.Configurations
{
    public class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(d => d.Cases)
                .WithOne(c => c.Diagnosis)
                .HasForeignKey(c => c.DiagnosisId)
                .IsRequired();

            builder.HasIndex(d => d.Name, "UIX_Diagnostics_Name")
                .IsUnique();

            builder.HasData(SeedData.LoadDiagnostics());

            builder.ToTable("Diagnostics");
        }
    }
}
