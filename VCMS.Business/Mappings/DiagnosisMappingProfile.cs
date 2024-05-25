namespace VCMS.Business.Mappings
{
    public class DiagnosisMappingProfile : Profile
    {
        public DiagnosisMappingProfile()
        {
            CreateMap<Diagnosis, DiagnosisDto>();
            CreateMap<DiagnosisDto, Diagnosis>();
        }
    }
}
