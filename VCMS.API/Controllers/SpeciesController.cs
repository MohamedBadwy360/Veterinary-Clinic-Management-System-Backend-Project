namespace VCMS.API.Controllers
{
    /// <summary>
    /// A controller for handling species related requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        /// <summary>
        /// A service for handling species related operations.
        /// </summary>
        private readonly ISpeciesService _speciesService;

        /// <summary>
        /// A constructor for initializing the species service.
        /// </summary>
        /// <param name="speciesService">
        /// The species service to be used for handling species related operations.
        /// </param>
        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        /// <summary>
        /// Get a species by Id.
        /// </summary>
        /// <param name="id">
        /// The Id of the species to be retrieved.
        /// </param>
        /// <returns>
        /// A response containing the species with the given Id.
        /// </returns>
        /// <response code="200">Returns the species with the specified Id.</response>
        /// <response code="404">If the species with the specified Id is not found.</response>
        /// <response code="500">If an error occurs while processing the request.</response>
        [SwaggerOperation(Summary = "Get species by Id", 
            Description = "Get species by Id from database.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpeciesById(int id)
        {
            var response = await _speciesService.GetSpeciesByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        /// <summary>
        /// Get list of all species.
        /// </summary>
        /// <returns>
        /// A response containing a list of all species.
        /// </returns>
        /// <response code="200">Returns a list of all species.</response>
        /// <response code="404">If no species are found in the database.</response>
        /// <response code="500">If an error occurs while processing the request.</response>
        [SwaggerOperation(Summary = "Get all species",
            Description = "Get species by Id from database.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet]
        public async Task<IActionResult> GetAllSpecies()
        {
            var response = await _speciesService.GetAllSpeciesAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        /// <summary>
        /// Create a species.
        /// </summary>
        /// <param name="speciesDto">
        /// A species data transfer object containing the details of the species to be created.
        /// </param>
        /// <returns>
        /// A response containing the created species.
        /// </returns>
        /// <response code="201">Returns the created species if created successfully.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="500">If an error occurs while processing the request.</response>
        [SwaggerOperation(Summary = "Create a species.",
            Description = "Create a species in the database.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status400BadRequest)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPost]
        public async Task<IActionResult> CreateSpecies(SpeciesDto speciesDto)
        {
            var response = await _speciesService.CreateSpeciesAsync(speciesDto);
            return StatusCode((int)response.StatusCode, response);
        }


        /// <summary>
        /// Update a species by Id.
        /// </summary>
        /// <param name="id">
        /// The Id of the species to be updated.
        /// </param>
        /// <param name="speciesDto">
        /// A species data transfer object containing the details of the species to be updated.
        /// </param>
        /// <returns>
        /// A response containing the updated species.
        /// </returns>
        /// < response code="200">Returns the updated species if updated successfully.</response>
        /// <response code="404">If the species with the specified Id is not found.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="500">If an error occurs while processing the request.</response>
        [SwaggerOperation(Summary = "Update a species by Id",
            Description = "Update a species by Id and name sent in the request body.")]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status400BadRequest)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut]
        public async Task<IActionResult> UpdateSpeciesById(int id, SpeciesDto speciesDto)
        {
            var response = await _speciesService.UpdateSpeciesByIdAsync(id, speciesDto);
            return StatusCode((int)response.StatusCode, response);
        }


        /// <summary>
        /// Delete a species by Id.
        /// </summary>
        /// <param name="id">
        /// The Id of the species to be deleted.
        /// </param>
        /// <returns>
        /// A response containing the deleted species.
        /// </returns>
        /// <response code="204">If the species is deleted successfully.</response>
        /// <response code="404">If the species with the specified Id is not found.</response>
        /// <response code="500">If an error occurs while processing the request.</response>
        [SwaggerOperation(Summary = "Delete a species with Id", 
            Description = "Delete a species with Id from database.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<SpeciesDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSpeciesById(int id)
        {
            var response = await _speciesService.DeleteSpeciesByIdAsync(id);
            return ((int)response.StatusCode == StatusCodes.Status204NoContent) ? NoContent() : 
                StatusCode((int)response.StatusCode, response);
        }
    }
}
