namespace VCMS.API.Extensions
{
    public static class RegisteringServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISpeciesService, SpeciesService>();
        }
    }
}
