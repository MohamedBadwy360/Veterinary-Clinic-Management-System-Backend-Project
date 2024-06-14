namespace VCMS.API.Controllers
{
    /// <summary>
    /// A controller for handling prescription-related requests.
    /// </summary>
    /// <param name="_prescriptionsService">
    /// Service for handling prescription-related requests.
    /// </param>
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController(IPrescriptionsService _prescriptionsService) : ControllerBase
    {
        /// <summary>
        /// Get a prescription by Id.
        /// </summary>
        /// <param name="id">
        /// Id of the prescription to get.
        /// </param>
        /// <returns>
        /// Response <see cref="Response{GetPrescriptionDto}"/> containing the prescription with the given Id.
        /// </returns>
        [SwaggerOperation(Summary = "Get a prescription by Id")]
        [ProducesResponseType(typeof(Response<GetPrescriptionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<GetPrescriptionDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPrescriptionById(int id)
        {
            var response = await _prescriptionsService.GetPrescriptionByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        /// <summary>
        /// Get a list of all prescriptions.
        /// </summary>
        /// <returns>
        /// Response <see cref="Response{IEnumerable{GetPrescriptionDto}}"/> containing a list of all prescriptions.
        /// </returns>
        [SwaggerOperation(Summary = "Get all prescriptions")]
        [ProducesResponseType(typeof(Response<IEnumerable<GetPrescriptionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<GetPrescriptionDto>>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet]
        public async Task<IActionResult> GetAllPrescription()
        {
            var response = await _prescriptionsService.GetAllPrescriptionsAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        /// <summary>
        /// Create a prescription.
        /// </summary>
        /// <param name="createPrescriptionDto">
        /// Prescription data to be created.
        /// </param>
        /// <returns>
        /// A respone <see cref="Response{CreatePrescriptionDto}"/>  with the created prescription if succeeded.
        /// </returns>
        [SwaggerOperation(Summary = "Create a prescription")]
        [ProducesResponseType(typeof(Response<CreatePrescriptionDto>), StatusCodes.Status201Created)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpPost]
        public async Task<IActionResult> CreatePrescription(CreatePrescriptionDto createPrescriptionDto)
        {
            var response = await _prescriptionsService.CreatePrescriptionAsync(createPrescriptionDto);
            return StatusCode((int)response.StatusCode, response);
        }


        /// <summary>
        /// Update a prescription.
        /// </summary>
        /// <param name="id">
        /// Id of prescription to be updated.
        /// </param>
        /// <param name="updatePrescriptionDto">
        /// Prescription data to be updated.
        /// </param>
        /// <returns>
        /// A response <see cref="Response{UpdatePrescriptionDto}"/> 
        /// </returns>
        [SwaggerOperation(Summary = "Update a prescription")]
        [ProducesResponseType(typeof(Response<UpdatePrescriptionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<UpdatePrescriptionDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut]
        public async Task<IActionResult> UpdatePrescription(int id, UpdatePrescriptionDto updatePrescriptionDto)
        {
            var response = await _prescriptionsService.UpdatePrescriptionAsync(id, updatePrescriptionDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a prescription")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<DeletePrescriptionDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            var response = await _prescriptionsService.DeletePrescriptionAsync(id);
            return (response.StatusCode == EResponseStatusCode.NoContent) ? NoContent() :
                StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Add a medication to a prescription")]
        [ProducesResponseType(typeof(PrescribedMedsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PrescribedMedsDto), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut("[action]")]
        public async Task<IActionResult> AddMedicationToPrescription(int prescriptionId, int medicationId, 
            int quantity, string frequency)
        {
            var response = await _prescriptionsService.AddMedicationToPrescription(prescriptionId, 
                medicationId, quantity, frequency);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a medication from a prescription")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(PrescribedMedsDto), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteMedicationFromPrescription(int prescriptionId, int medicationId)
        {
            var response = await _prescriptionsService.DeleteMedicationFromPrescription(prescriptionId, 
                medicationId);
            return (response.StatusCode == EResponseStatusCode.NoContent) ? NoContent() : 
                StatusCode((int)response.StatusCode, response);
        }
    }
}
