namespace VCMS.Tests.VCMS.API.Tests.Controllers
{
    public class SpeciesControllerTests
    {
        [Fact]
        public async Task GetSpeciesById_WhenSpeciesDoesNotExists_ReturnsNotFoundResponse()
        {
            // Arrange
            var id = 1;
            var expectedResponse = ResponseFactory.NotFound<SpeciesDto>(id);

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.GetSpeciesByIdAsync(id))
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.GetSpeciesById(id);

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value);
        }
        
        [Fact]
        public async Task GetSpeciesById_WhenSpeciesExists_ReturnsOkResponse()
        {
            // Arrange
            var id = 1;
            var speciesDto = new SpeciesDto { Name = "Species1" };
            var expectedResponse = ResponseFactory.Ok(speciesDto);

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.GetSpeciesByIdAsync(id))
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.GetSpeciesById(id);

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value);
        }

        [Fact]
        public async Task GetAllSpecies_WhenSpeciesDoNotExist_ReturnsNotFoundResponse()
        {
            // Arrange
            var expectedResponse = ResponseFactory.NotFound<IEnumerable<SpeciesDto>>();

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.GetAllSpeciesAsync())
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.GetAllSpecies();

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value);
        }

        [Fact]
        public async Task GetAllSpecies_WhenSpeciesExist_ReturnsOkResponse()
        {
            // Arrange
            IEnumerable<SpeciesDto> speciesDtos =  new List<SpeciesDto>
            {
                new SpeciesDto { Name = "Cat" },
                new SpeciesDto { Name = "Dog" }
            };

            var expectedResponse = ResponseFactory.Ok(speciesDtos);

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.GetAllSpeciesAsync())
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.GetAllSpecies();

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value);
        }

        [Fact]
        public async Task CreateSpecies_WhenSpeciesDtoIsValid_ReturnsCreatedResponse()
        {
            // Arrange
            var speciesDto = new SpeciesDto { Name = "Cat" };

            var expectedResponse = ResponseFactory.Created(speciesDto);

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.CreateSpeciesAsync(speciesDto))
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.CreateSpecies(speciesDto);

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value);
        }

        [Fact]
        public async Task CreateSpecies_WhenSpeciesDtoIsInvalid_ReturnsBadRequestResponse()
        {
            // Arrange
            var speciesDto = new SpeciesDto { Name = "Cat!" };

            var expectedResponse = ResponseFactory.BadRequest<SpeciesDto>("You inserted incorrect letter in species name.");

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.CreateSpeciesAsync(speciesDto))
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.CreateSpecies(speciesDto);

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value);
        }

        [Fact]
        public async Task UpdateSpecies_WhenSpeciesDtoIsInvalid_ReturnsBadRequestResponse()
        {
            // Arrange
            var speciesDto = new SpeciesDto { Name = "Cat!" };
            int id = 1;

            var expectedResponse = ResponseFactory.BadRequest<SpeciesDto>("You inserted incorrect letter in species name.");

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.UpdateSpeciesByIdAsync(id, speciesDto))
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.UpdateSpeciesById(id, speciesDto);

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value); 
        }

        [Fact]
        public async Task UpdateSpecies_WhenSpeciesDtoIsValidAndSpeciesDoesNotExist_ReturnsNotFoundResponse()
        {
            // Arrange
            var speciesDto = new SpeciesDto { Name = "Cat" };
            int id = 1;

            var expectedResponse = ResponseFactory.NotFound<SpeciesDto>(id);

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.UpdateSpeciesByIdAsync(id, speciesDto))
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.UpdateSpeciesById(id, speciesDto);

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value);
        }

        [Fact]
        public async Task UpdateSpecies_WhenSpeciesDtoIsValidAndSpeciesExists_ReturnsOkResponse()
        {
            // Arrange
            var speciesDto = new SpeciesDto { Name = "Cat" };
            int id = 1;

            var expectedResponse = ResponseFactory.Ok(speciesDto);

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.UpdateSpeciesByIdAsync(id, speciesDto))
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.UpdateSpeciesById(id, speciesDto);

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value);
        }

        [Fact]
        public async Task DeleteSpecies_WhenSpeciesDoesNotExist_ReturnsNotFoundResponse()
        {
            // Arrange
            int id = 1;

            var expectedResponse = ResponseFactory.NotFound<SpeciesDto>(id);

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.DeleteSpeciesByIdAsync(id))
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.DeleteSpeciesById(id);

            // Assert
            Assert.IsType<ObjectResult>(actualResponse);
            var objectResult = actualResponse as ObjectResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
            Assert.Equal(expectedResponse, objectResult.Value);
        }

        [Fact]
        public async Task DeleteSpecies_WhenSpeciesExists_ReturnsNoContentResponse()
        {
            // Arrange
            int id = 1;

            var expectedResponse = ResponseFactory.NoContent<SpeciesDto>();

            var speciesServiceMock = new Mock<ISpeciesService>();
            speciesServiceMock.Setup(speciesService => speciesService.DeleteSpeciesByIdAsync(id))
                .ReturnsAsync(expectedResponse);

            var speciesController = new SpeciesController(speciesServiceMock.Object);

            // Act
            var actualResponse = await speciesController.DeleteSpeciesById(id);

            // Assert
            Assert.IsType<NoContentResult>(actualResponse);
            var objectResult = actualResponse as NoContentResult;
            Assert.Equal((int)expectedResponse.StatusCode, objectResult.StatusCode);
        }
    }
}
