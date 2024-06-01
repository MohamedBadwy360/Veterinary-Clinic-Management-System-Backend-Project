namespace VCMS.Business.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, GetPatientDto>()
                .ForMember(dest => dest.ClientName, options => options.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"))
                .ForMember(dest => dest.SpeciesName, options => options.MapFrom(src => src.Species.Name));

            CreateMap<CreatePatientDto, Patient>();
            CreateMap<UpdatePatientDto, Patient>();
            CreateMap<Patient, DeletePatientDto>();
        }
    }
}
