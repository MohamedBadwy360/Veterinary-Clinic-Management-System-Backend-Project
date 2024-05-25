namespace VCMS.API.Extensions
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SpeciesMappingProfile).Assembly);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISpeciesService, SpeciesService>();
            services.AddScoped<IDiagnosisService, DiagnosisService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
