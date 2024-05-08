
using System.Data;

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
                .HasColumnType("TINYINT")
                .IsRequired();

            builder.Property(c => c.CaseType)
                .HasColumnType("TINYINT")
                .IsRequired();

            builder.Property(c => c.Date)
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(c => c.Notes)
                .HasColumnType("VARCHAR")
                .HasMaxLength(1000);

            builder.ToTable("Cases");
        }
    }
}
