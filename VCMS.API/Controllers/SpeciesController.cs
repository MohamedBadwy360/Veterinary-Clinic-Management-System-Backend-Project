namespace VCMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService _speciesService;
        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        [SwaggerOperation(Summary = "Get species by Id", 
            Description = "Get species by Id from database.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status500InternalServerError)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpeciesById(int id)
        {
            var response = await _speciesService.GetSpeciesByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Get all species",
            Description = "Get species by Id from database.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status500InternalServerError)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSpecies()
        {
            var response = await _speciesService.GetAllSpeciesAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Create a species.",
            Description = "Create a species in the database.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status500InternalServerError)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPost]
        public async Task<IActionResult> CreateSpecies(SpeciesDto speciesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _speciesService.CreateSpeciesAsync(speciesDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Update a species by Id",
            Description = "Update a species by Id and name sent in the request body.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> UpdateSpeciesById(int id, SpeciesDto speciesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _speciesService.UpdateSpeciesByIdAsync(id, speciesDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a species with Id", 
            Description = "Delete a species with Id from database.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSpeciesById(int id)
        {
            var response = await _speciesService.DeleteSpeciesByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
