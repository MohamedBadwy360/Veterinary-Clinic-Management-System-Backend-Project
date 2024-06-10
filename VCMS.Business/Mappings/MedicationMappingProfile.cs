namespace VCMS.Business.Mappings
{
    public class MedicationMappingProfile : Profile
    {
        public MedicationMappingProfile()
        {
            CreateMap<Medication, MedicationDto>();
            CreateMap<MedicationDto, Medication>();
        }
    }
}
