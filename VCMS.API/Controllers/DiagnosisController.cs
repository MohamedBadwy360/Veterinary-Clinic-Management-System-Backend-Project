namespace VCMS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IDiagnosisService _diagnosisService;

        public DiagnosisController(IDiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
        }


        [SwaggerOperation(Summary = "Get a diagnosis by Id",
            Description = "Get a diagnosis by Id from database.")]
        [ProducesResponseType(typeof(Response<DiagnosisDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<DiagnosisDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDiagnosisById(int id)
        {
            var response = await _diagnosisService.GetDiagnosisByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Get all diagnostics", 
            Description = "Get all diagnostics from database.")]
        [ProducesResponseType(typeof(Response<IEnumerable<DiagnosisDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<DiagnosisDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet]
        public async Task<IActionResult> GetAllDiagnosis()
        {
            var response = await _diagnosisService.GetAllDiagnosisAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Create a diagnostics",
            Description = "Create a diagnostics in database.")]
        [ProducesResponseType(typeof(Response<DiagnosisDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<DiagnosisDto>), StatusCodes.Status400BadRequest)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPost]
        public async Task<IActionResult> CreateDiagnosis(DiagnosisDto diagnosisDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _diagnosisService.CreateDiagnosisAsync(diagnosisDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Update a diagnostics",
            Description = "Update a diagnostics in database.")]
        [ProducesResponseType(typeof(Response<DiagnosisDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<DiagnosisDto>), StatusCodes.Status400BadRequest)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut]
        public async Task<IActionResult>UpdateDiagnosis(int id, DiagnosisDto diagnosisDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _diagnosisService.UpdateDiagnosisByIdAsync(id, diagnosisDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a diagnostics",
            Description = "Delete a diagnostics in database.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<DiagnosisDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDiagnosis(int id)
        {
            var response = await _diagnosisService.DeleteDiagnosisByIdAsync(id);
            return ((int)response.StatusCode == StatusCodes.Status204NoContent) ? NoContent() :
                StatusCode((int)response.StatusCode, response);
        }
    }
}
