namespace VCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasesController : ControllerBase
    {
        private readonly ICasesService _casesService;

        public CasesController(ICasesService casesService)
        {
            _casesService = casesService;
        }


        [SwaggerOperation(Summary = "Get a case by Id",
            Description = "Get a case by Id from database.")]
        [ProducesResponseType(typeof(Response<GetCaseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<GetCaseDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCaseById(int id)
        {
            var response = await _casesService.GetCaseByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Get all cases",
            Description = "Get all cases from database.")]
        [ProducesResponseType(typeof(Response<IEnumerable<GetCaseDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<GetCaseDto>>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet]
        public async Task<IActionResult> GetAllCases()
        {
            var response = await _casesService.GetAllCasesAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Create a case",
            Description = "Create a case in the database. " +
            "Case Type should be 0 or 1. 0 for Medical and 1 for Surgical. " +
            "Case Status should be 0 or 1. 0 for NewCase and 1 for UpdatedCase.")]
        [ProducesResponseType(typeof(Response<CreateCaseDto>), StatusCodes.Status200OK)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpPost]
        public async Task<IActionResult> CreateCase(CreateCaseDto createCaseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _casesService.CreateCaseAsync(createCaseDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Update a case",
            Description = "Update a case in the database.")]
        [ProducesResponseType(typeof(Response<UpdateCaseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<UpdateCaseDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut]
        public async Task<IActionResult> UpdateCase(int id, UpdateCaseDto updateCaseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _casesService.UpdateCaseAsync(id, updateCaseDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a case",
            Description = "Delete a case from the database.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<DeleteCaseDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var response = await _casesService.DeleteCaseAsync(id);
            return (response.StatusCode == EResponseStatusCode.NoContent) ? NoContent() : 
                StatusCode((int)response.StatusCode, response);
        }
    }
}
