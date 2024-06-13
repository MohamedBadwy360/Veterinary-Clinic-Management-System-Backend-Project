using System.Formats.Asn1;

namespace VCMS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsService _doctorsService;

        public DoctorsController(IDoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }


        [SwaggerOperation(Summary = "Get a doctor by Id", 
            Description = "Get a doctor by Id from database.")]
        [ProducesResponseType(typeof(Response<DoctorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<DoctorDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var response = await _doctorsService.GetDoctorByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Get all doctors",
            Description = "Get all doctors from database.")]
        [ProducesResponseType(typeof(Response<IEnumerable<DoctorDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<DoctorDto>>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var response = await _doctorsService.GetAllDoctorsAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Create a doctor",
            Description = "Create a doctor in database.")]
        [ProducesResponseType(typeof(Response<DoctorDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<DoctorDto>), StatusCodes.Status400BadRequest)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorDto doctorDto)
        {
            var response = await _doctorsService.CreateDoctorAsync(doctorDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Update a doctor",
            Description = "Update a doctor in database.")]
        [ProducesResponseType(typeof(Response<DoctorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<DoctorDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorDto doctorDto)
        {
            var response = await _doctorsService.UpdateDoctorAsync(id, doctorDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a doctor",
            Description = "Delete a doctor by Id from database.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<DoctorDto>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var response = await _doctorsService.DeleteDoctorByIdAsync(id);
            return (response.StatusCode == EResponseStatusCode.NoContent) ? NoContent() :
                StatusCode((int)response.StatusCode, response);
        }
    }
}
