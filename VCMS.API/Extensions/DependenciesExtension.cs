namespace VCMS.API.Extensions
{
    public static class DependenciesExtension
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SpeciesMappingProfile).Assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISpeciesService, SpeciesService>();
            services.AddScoped<IDiagnosisService, DiagnosisService>();
            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IPatientsService, PatientsService>();
            services.AddScoped<IDoctorsService, DoctorsService>();
            services.AddScoped<ICasesService, CasesService>();
            services.AddScoped<IMedicationsService, MedicationsService>();
            services.AddScoped<IPrescriptionsService, PrescriptionsService>();
            services.AddScoped<IReceiptsService, ReceiptsService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
