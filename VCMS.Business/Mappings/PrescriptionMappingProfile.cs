namespace VCMS.Business.Mappings
{
    public class PrescriptionMappingProfile : Profile
    {
        public PrescriptionMappingProfile()
        {
            CreateMap<Prescription, GetPrescriptionDto>()
                .ForMember(dest => dest.PrescribedMedcations, options => options.MapFrom(src => src.PrescribedMeds));

            CreateMap<PrescribedMeds, GetPrescribedMedDto>()
                .ForMember(dest => dest.MedicationName, options => options.MapFrom(src => src.Medication.TradeName));

            CreateMap<CreatePrescriptionDto, Prescription>();
            CreateMap<UpdatePrescriptionDto, Prescription>();

            CreateMap<PrescribedMeds, PrescribedMedsDto>();
        }
    }
}
