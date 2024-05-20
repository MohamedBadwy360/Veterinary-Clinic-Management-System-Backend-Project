namespace VCMS.EF.Data.Configurations
{
    public class CaseConfiguration : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Status)
                .HasColumnType(SqlServerDataTypes.TINYINT)
                .IsRequired();

            builder.Property(c => c.CaseType)
                .HasColumnType(SqlServerDataTypes.TINYINT)
                .IsRequired();

            builder.Property(c => c.Date)
                .HasColumnType(SqlServerDataTypes.DATE)
                .IsRequired();

            builder.Property(c => c.Notes)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(1000);

            builder.HasData(SeedData.LoadCases());

            builder.ToTable("Cases");
        }
    }
}
