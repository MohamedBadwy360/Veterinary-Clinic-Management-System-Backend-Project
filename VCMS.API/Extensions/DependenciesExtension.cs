﻿namespace VCMS.API.Extensions
{
    public static class DependenciesExtension
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SpeciesMappingProfile).Assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISpeciesService, SpeciesService>();
            services.AddScoped<IDiagnosisService, DiagnosisService>();
            services.AddScoped<IClientService, ClientsService>();
            services.AddScoped<IPatientService, PatientsService>();
        }
    }
}