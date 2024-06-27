namespace VCMS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationsService _medicationsService;

        public MedicationsController(IMedicationsService medicationsService)
        {
            _medicationsService = medicationsService;
        }


        [SwaggerOperation(Summary = "Get a medication by Id",
            Description = "Get a medication by id from database.")]
        [ProducesResponseType(typeof(Response<MedicationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<MedicationDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [Authorize(Roles = Roles.User)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMedicationbyId(int id)
        {
            var response = await _medicationsService.GetMedicationByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Get all medications",
            Description = "Get all medications from database.")]
        [ProducesResponseType(typeof(Response<IEnumerable<MedicationDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<MedicationDto>>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [Authorize(Roles = Roles.User)]
        [HttpGet]
        public async Task<IActionResult> GetAllMedication()
        {
            var response = await _medicationsService.GetAllMedicationsAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Create a medication",
            Description = "Create a medication in database.")]
        [ProducesResponseType(typeof(Response<MedicationDto>), StatusCodes.Status201Created)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpPost]
        public async Task<IActionResult> CreateMedication(MedicationDto medicationDto)
        {
            var response = await _medicationsService.CreateMedicationAsync(medicationDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Update a medication",
            Description = "Update a medication in database.")]
        [ProducesResponseType(typeof(Response<MedicationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<MedicationDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut]
        public async Task<IActionResult> UpdateMedication(int id, MedicationDto medicationDto)
        {
            var response = await _medicationsService.UpdateMedicationAsync(id, medicationDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a medication",
            Description = "Delete a medication in database.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<MedicationDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            var response = await _medicationsService.DeleteMedicationAsync(id);
            return (response.StatusCode == EResponseStatusCode.NoContent) ? NoContent() :
                StatusCode((int)response.StatusCode, response);
        }
    }
}
