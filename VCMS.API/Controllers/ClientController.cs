using Microsoft.AspNetCore.Mvc.Formatters;

namespace VCMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }



        [SwaggerOperation(Summary = "Get a client by Id", 
            Description = "Get client by Id from database.")]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status500InternalServerError)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var response = await _clientService.GetClientByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Get all clients",
            Description = "Get all clients from database.")]
        [ProducesResponseType(typeof(Response<IEnumerable<ClientDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<ClientDto>>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<IEnumerable<ClientDto>>), StatusCodes.Status500InternalServerError)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var response = await _clientService.GetAllClientAsync();
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Create a client",
            Description = "Create client in the database.")]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<ValidationProblemDetails>), StatusCodes.Status400BadRequest)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _clientService.CreateClientAsync(clientDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Update a client",
            Description = "Update client in the database.")]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<ValidationProblemDetails>), StatusCodes.Status400BadRequest)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpPut]
        public async Task<IActionResult> UpdateClient(int id, ClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _clientService.UpdateClientByIdAsync(id, clientDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Delete a client",
            Description = "Delete client from the database.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<ClientDto>), StatusCodes.Status500InternalServerError)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var response = await _clientService.DeleteClientByIdAsync(id);
            return ((int)response.StatusCode == StatusCodes.Status204NoContent) ? NoContent() :
                StatusCode((int)response.StatusCode, response);
        }
    }
}
