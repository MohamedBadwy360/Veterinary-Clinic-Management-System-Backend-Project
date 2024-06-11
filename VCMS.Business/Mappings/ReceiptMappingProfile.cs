namespace VCMS.Business.Mappings
{
    public class ReceiptMappingProfile : Profile
    {
        public ReceiptMappingProfile()
        {
            CreateMap<Receipt, GetReceiptDto>();
            CreateMap<GetReceiptDto, Receipt>();

            CreateMap<CreateReceiptDto, Receipt>();
            CreateMap<UpdateReceiptDto, Receipt>();
        }
    }
}
