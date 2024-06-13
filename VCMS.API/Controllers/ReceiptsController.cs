using VCMS.Core.Dtos.ReceiptDtos;

namespace VCMS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class ReceiptsController(IReceiptsService _receiptsService) : ControllerBase
    {
        [SwaggerOperation(Summary = "Get a receipt by Id")]
        [ProducesResponseType(typeof(Response<GetReceiptDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<GetReceiptDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [Authorize(Roles = Roles.User)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReceiptById(int id)
        {
            var response = await _receiptsService.GetReceiptByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Get all receipts")]
        [ProducesResponseType(typeof(Response<IEnumerable<GetReceiptDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<GetReceiptDto>>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet]
        public async Task<IActionResult> GetAllReceipts()
        {
            var response = await _receiptsService.GetAllReceiptsAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Create a receipt")]
        [ProducesResponseType(typeof(Response<CreateReceiptDto>), StatusCodes.Status201Created)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpPost]
        public async Task<IActionResult> CreateReceipt(CreateReceiptDto createReceiptDto)
        {
            var response = await _receiptsService.CreateReceiptAsync(createReceiptDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Update a receipt")]
        [ProducesResponseType(typeof(Response<UpdateReceiptDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<UpdateReceiptDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut]
        public async Task<IActionResult> UpdateReceipt(int id, UpdateReceiptDto updateReceiptDto)
        {
            var response = await _receiptsService.UpdateReceiptAsync(id, updateReceiptDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a receipt")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<DeleteReceiptDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            var response = await _receiptsService.DeleteReceiptAsync(id);
            return (response.StatusCode == EResponseStatusCode.NoContent) ? NoContent() :
                StatusCode((int)response.StatusCode, response);
        }
    }
}
