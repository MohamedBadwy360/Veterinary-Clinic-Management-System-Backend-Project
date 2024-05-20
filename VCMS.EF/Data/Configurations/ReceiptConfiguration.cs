namespace VCMS.EF.Data.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Date)
                .HasColumnType(SqlServerDataTypes.DATE)
                .IsRequired();

            builder.Property(r => r.TotalPrice)
                .HasPrecision(8, 2)
                .IsRequired();

            builder.HasOne(r => r.Prescription)
                .WithOne(p => p.Receipt)
                .HasForeignKey<Receipt>(r => r.PrescriptionId)
                .IsRequired();

            builder.HasData(SeedData.LoadReceipts());

            builder.ToTable("Receipts");
        }
    }
}
