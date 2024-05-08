﻿namespace VCMS.EF.Data.Configurations
{
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(s => s.Patients)
                .WithOne(p => p.Species)
                .HasForeignKey(p => p.SpeciesId)
                .IsRequired();

            builder.ToTable("Species");
        }
    }
}
