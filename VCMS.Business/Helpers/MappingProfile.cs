namespace VCMS.Business.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Species, SpeciesDto>();
            CreateMap<SpeciesDto, Species>();
        }
    }
}
