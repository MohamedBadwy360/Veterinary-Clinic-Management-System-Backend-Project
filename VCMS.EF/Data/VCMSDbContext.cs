using Microsoft.EntityFrameworkCore;
using VCMS.EF.Data.Configurations;

namespace VCMS.EF.Data
{
    public class VCMSDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpeciesConfiguration).Assembly);
        }
    }
}
