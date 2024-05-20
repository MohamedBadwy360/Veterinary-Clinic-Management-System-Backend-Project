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
            var species = await _speciesService.GetByIdAsync(id);
            return StatusCode((int)species.StatusCode, species);
        }



        [SwaggerOperation(Summary = "Get species by Id",
            Description = "Get species by Id from database.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status500InternalServerError)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSpecies()
        {
            var species = await _speciesService.GetAllAsync();
            return StatusCode((int)species.StatusCode, species);
        }




        [SwaggerOperation(Summary = "Create a species.",
            Description = "Create a species in the database.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status500InternalServerError)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSpecies(SpeciesDto speciesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var species = await _speciesService.CreateAsync(speciesDto);
            return StatusCode((int)species.StatusCode, species);
        }
    }
}
