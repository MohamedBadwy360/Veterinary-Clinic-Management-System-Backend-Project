
namespace VCMS.EF.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.FirstName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Address)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
                .HasColumnType("VARCHAR")
                .HasMaxLength(15)
                .IsRequired();

            builder.HasMany(c => c.Patients)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId)
                .IsRequired();

            builder.ToTable("Clients");
        }
    }
}
