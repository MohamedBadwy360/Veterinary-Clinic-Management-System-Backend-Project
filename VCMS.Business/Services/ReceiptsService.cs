namespace VCMS.Business.Services
{
    public class ReceiptsService(IUnitOfWork _unitOfWork, IMapper _mapper) : IReceiptsService
    {
        public async Task<Response<GetReceiptDto>> GetReceiptByIdAsync(int id)
        {
            var receipt = await _unitOfWork.Receipts.GetByIdAsync(id);
            if (receipt is null)
            {
                return ResponseFactory.NotFound<GetReceiptDto>(id);
            }

            var receiptDto = _mapper.Map<GetReceiptDto>(receipt);
            return ResponseFactory.Ok(receiptDto);
        }

        public async Task<Response<IEnumerable<GetReceiptDto>>> GetAllReceiptsAsync()
        {
            var receipts = await _unitOfWork.Receipts.GetAllAsync();
            if (receipts is null)
            {
                return ResponseFactory.NotFound<IEnumerable<GetReceiptDto>>();
            }

            var receiptDtos = _mapper.Map<IEnumerable<GetReceiptDto>>(receipts);
            return ResponseFactory.Ok(receiptDtos);
        }

        public async Task<Response<CreateReceiptDto>> CreateReceiptAsync(CreateReceiptDto createReceiptDto)
        {
            var receipt = _mapper.Map<Receipt>(createReceiptDto);
            receipt.TotalPrice = await _unitOfWork.Receipts
                    .GetReceiptTotalPriceByPrescriptionId(createReceiptDto.PrescriptionId);

            await _unitOfWork.Receipts.AddAsync(receipt);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Created(createReceiptDto);
        }

        public async Task<Response<UpdateReceiptDto>> UpdateReceiptAsync(int id, 
            UpdateReceiptDto updateReceiptDto)
        {
            var receipt = await _unitOfWork.Receipts.GetByIdAsync(id);
            if (receipt is null)
            {
                return ResponseFactory.NotFound<UpdateReceiptDto>(id);
            }

            _mapper.Map(updateReceiptDto, receipt);
            receipt.TotalPrice = await _unitOfWork.Receipts
                .GetReceiptTotalPriceByPrescriptionId(updateReceiptDto.PrescriptionId);

            _unitOfWork.Receipts.Update(receipt);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Ok(updateReceiptDto);
        }

        public async Task<Response<DeleteReceiptDto>> DeleteReceiptAsync(int id)
        {
            var receipt = await _unitOfWork.Receipts.GetByIdAsync(id);
            if (receipt is null)
            {
                return ResponseFactory.NotFound<DeleteReceiptDto>(id);
            }

            _unitOfWork.Receipts.Delete(receipt);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.NoContent<DeleteReceiptDto>();
        } 
    }
}
