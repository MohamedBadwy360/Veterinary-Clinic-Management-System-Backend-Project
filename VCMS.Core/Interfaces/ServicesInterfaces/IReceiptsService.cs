namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface IReceiptsService
    {
        Task<Response<GetReceiptDto>> GetReceiptByIdAsync(int id);
        Task<Response<IEnumerable<GetReceiptDto>>> GetAllReceiptsAsync();
        Task<Response<CreateReceiptDto>> CreateReceiptAsync(CreateReceiptDto createReceiptDto);
        Task<Response<UpdateReceiptDto>> UpdateReceiptAsync(int id, UpdateReceiptDto updateReceiptDto);
        Task<Response<DeleteReceiptDto>> DeleteReceiptAsync(int id);
    }
}
