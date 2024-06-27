namespace VCMS.API.Controllers
{
    /// <summary>
    /// A controller for managing receipts.
    /// </summary>
    /// <param name="_receiptsService">
    /// A service for managing receipts.
    /// </param>
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class ReceiptsController(IReceiptsService _receiptsService) : ControllerBase
    {
        /// <summary>
        /// Get a receipt by Id.
        /// </summary>
        /// <param name="id">
        /// The Id of the receipt to get.
        /// </param>
        /// <returns>
        /// A response containing the receipt with the specified Id.
        /// </returns>
        /// <response code="200">Resturns the receipt with the specified Id if exists.</response>
        /// <response code="404">If the receipt with the specified Id is not found.</response>
        /// <response code="500">If an error occurs while processing the request.</response>
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


        /// <summary>
        /// Get a list of all receipts.
        /// </summary>
        /// <returns>
        /// A response containing a list of all receipts.
        /// </returns>
        /// <response code="200">Returns a list of all receipts.</response>
        /// <response code="404">If no receipts are found in the database.</response>
        /// <response code="500">If an error occurs while processing the request.</response>
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


        /// <summary>
        /// Create a receipt.
        /// </summary>
        /// <param name="createReceiptDto">
        /// The receipt data to be created.
        /// </param>
        /// <returns>
        /// A response containing the created receipt.
        /// </returns>
        /// <response code="201">Returns the created receipt if succeeded.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="500">If an error occurs while processing the request.</response>
        [SwaggerOperation(Summary = "Create a receipt")]
        [ProducesResponseType(typeof(Response<CreateReceiptDto>), StatusCodes.Status201Created)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpPost]
        public async Task<IActionResult> CreateReceipt(CreateReceiptDto createReceiptDto)
        {
            var response = await _receiptsService.CreateReceiptAsync(createReceiptDto);
            return StatusCode((int)response.StatusCode, response);
        }


        /// <summary>
        /// Update a receipt.
        /// </summary>
        /// <param name="id">
        /// The Id of the receipt to be updated.
        /// </param>
        /// <param name="updateReceiptDto">
        /// The receipt data to be updated.
        /// </param>
        /// <returns>
        /// A response containing the updated receipt.
        /// </returns>
        /// <response code="200">Returns the updated receipt if succeeded.</response>
        /// <response code="404">If the receipt with the specified Id is not found.</response>
        /// <response code="500">If an error occurs while processing the request.</response>
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


        /// <summary>
        /// Delete a receipt.
        /// </summary>
        /// <param name="id">
        /// Id of the receipt to be deleted.
        /// </param>
        /// <returns>
        /// Returns 204 No Content if the receipt is deleted successfully.
        /// </returns>
        [SwaggerOperation(Summary = "Delete a receipt")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<DeleteReceiptDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            var response = await _receiptsService.DeleteReceiptAsync(id);
            return (response.StatusCode == EResponseStatusCode.NoContent) ? NoContent() :
                StatusCode((int)response.StatusCode, response);
        }
    }
}
