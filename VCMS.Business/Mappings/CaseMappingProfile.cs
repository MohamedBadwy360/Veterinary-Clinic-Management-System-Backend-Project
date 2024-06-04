namespace VCMS.Business.Mappings
{
    public class CaseMappingProfile : Profile
    {
        public CaseMappingProfile()
        {
            CreateMap<Case, GetCaseDto>()
                .ForMember(dest => dest.ClientName, options => options.MapFrom(src => $"{src.Patient.Client.FirstName} {src.Patient.Client.LastName}"))
                .ForMember(dest => dest.SpeciesName, options => options.MapFrom(src => src.Patient.Species.Name))
                .ForMember(dest => dest.DiagnosisName, options => options.MapFrom(src => src.Diagnosis.Name))
                .ForMember(dest => dest.DoctorName, options => options.MapFrom(src => $"{src.Doctor.FirstName} {src.Doctor.LastName}"))
                .ForMember(dest => dest.Status, options => options.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.CaseType, options => options.MapFrom(src => src.CaseType.ToString()));

            CreateMap<CreateCaseDto, Case>();
            CreateMap<UpdateCaseDto, Case>();
        }
    }
}
