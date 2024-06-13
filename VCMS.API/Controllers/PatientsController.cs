namespace VCMS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _patientsService;

        public PatientsController(IPatientsService patientsService)
        {
            _patientsService = patientsService;
        }



        [SwaggerOperation(Summary = "Get a patient by Id", 
            Description = "Get a patient by Id from database.")]
        [ProducesResponseType(typeof(Response<GetPatientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<GetPatientDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [Authorize(Roles = Roles.User)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var response = await _patientsService.GetPatientByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Get all patients", 
            Description = "Get all patients and their navigational properities name from database.")]
        [ProducesResponseType(typeof(Response<IEnumerable<GetPatientDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<GetPatientDto>>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var response = await _patientsService.GetAllPatientsAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Create a patient",
            Description = "Create a patient in database.")]
        [ProducesResponseType(typeof(Response<GetPatientDto>), StatusCodes.Status201Created)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPost]
        public async Task<IActionResult> CreatePatient(CreatePatientDto createPatientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _patientsService.CreatePatientAsync(createPatientDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Update a patient",
            Description = "Update a patient in database.")]
        [ProducesResponseType(typeof(Response<UpdatePatientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<UpdatePatientDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut]
        public async Task<IActionResult> UpdatePatient(int id, UpdatePatientDto updatePatientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _patientsService.UpdatePatientAsync(id, updatePatientDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a patient",
            Description = "Delete a patient in database.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<DeletePatientDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var response = await _patientsService.DeletePatientAsync(id);
            return (response.StatusCode == EResponseStatusCode.NoContent) ? NoContent() : 
                StatusCode((int)response.StatusCode, response);
        }
    }
}
