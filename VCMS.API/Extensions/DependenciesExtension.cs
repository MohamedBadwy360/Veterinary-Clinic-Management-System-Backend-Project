namespace VCMS.API.Extensions
{
    public static class DependenciesExtension
    {
        /// <summary>
        /// A method to register all dependencies in the application
        /// </summary>
        /// <param name="services">
        /// A collection of service descriptors
        /// </param>
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
        }
    }
}
