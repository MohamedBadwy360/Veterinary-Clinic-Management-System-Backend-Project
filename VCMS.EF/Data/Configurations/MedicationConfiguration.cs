
namespace VCMS.EF.Data.Configurations
{
    public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.TradeName)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.GenericName)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(50);

            builder.Property(m => m.Category)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Unit)
                .HasColumnType(SqlServerDataTypes.VARCHAR)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(m => m.UnitInStock)
                .IsRequired();

            builder.Property(m => m.CostPricePerItem)
                .HasPrecision(8, 2)
                .IsRequired();

            builder.Property(m => m.SalePricePerItem)
                .HasPrecision(8, 2)
                .IsRequired();

            builder.Property(m => m.ExpirationDate)
                .HasColumnType(SqlServerDataTypes.DATE)
                .IsRequired();

            builder.HasIndex(m => m.GenericName, "UIX_Medication_GenericName")
                .IsUnique();

            builder.HasData(SeedData.LoadMedications());

            builder.ToTable("Medications");
        }
    }
}
