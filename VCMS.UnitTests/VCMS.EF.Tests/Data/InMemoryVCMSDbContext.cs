namespace VCMS.Tests.VCMS.EF.Tests.Data
{
    public class InMemoryVCMSDbContext : VCMSDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }

        public override void Dispose()
        {
            Database.EnsureDeleted();
            base.Dispose();
        }
    }
}
