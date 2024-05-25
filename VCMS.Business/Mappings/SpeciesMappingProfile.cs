namespace VCMS.Business.Mappings
{
    public class SpeciesMappingProfile : Profile
    {
        public SpeciesMappingProfile()
        {
            CreateMap<Species, SpeciesDto>();
            CreateMap<SpeciesDto, Species>();
        }
    }
}
