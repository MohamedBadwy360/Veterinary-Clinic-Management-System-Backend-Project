namespace VCMS.Tests.VCMS.Business.Tests.Services
{
    public class SpeciesServiceTests
    {
        [Fact]
        public async Task GetSpeciesByIdAsync_WhenSpeciesDoesNotExist_ReturnsNotFoundResponse()
        {
            // Arrange
            Species species = null;
            int id = 1;
            
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(unitOfWorkMock => unitOfWorkMock.Species.GetByIdAsync(id)).ReturnsAsync(species);

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.NotFound<SpeciesDto>(id);

            // Act
            var actualResponse = await speciesService.GetSpeciesByIdAsync(id);

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task GetSpeciesByIdAsync_WhenSpeciesExists_ReturnsOkResponse()
        {
            // Arrange
            var species = new Species { Id = 1, Name = "Cat" };
            var speciesDto = new SpeciesDto { Name = "Cat" };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(unitOfWorkMock => unitOfWorkMock.Species.GetByIdAsync(1)).ReturnsAsync(species);
            mapperMock.Setup(mapperMock => mapperMock.Map<SpeciesDto>(species)).Returns(speciesDto);

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.Ok(speciesDto);

            // Act
            var actualResponse = await speciesService.GetSpeciesByIdAsync(1);

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact] 
        public async Task GetAllSpeciesAsync_WhenSpeciesDoNotExist_ReturnsNotFoundResponse()
        {
            List<Species> species = null;

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(unitOfWorkMock => unitOfWorkMock.Species.GetAllAsync()).ReturnsAsync(species);

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.NotFound<IEnumerable<SpeciesDto>>();

            // Act
            var actualResponse = await speciesService.GetAllSpeciesAsync();

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task GetAllSpeciesAsync_WhenSpeciesExists_ReturnsOkResponse()
        {
            IEnumerable<Species> species = new List<Species> 
            {
                new Species { Id = 1, Name = "Cat" }, 
                new Species { Id = 2, Name = "Dog" }
            };

            IEnumerable<SpeciesDto> speciesDtos = new List<SpeciesDto>
            {
                new SpeciesDto { Name = "Cat" },
                new SpeciesDto { Name = "Dog" }
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(unitOfWorkMock => unitOfWorkMock.Species.GetAllAsync()).ReturnsAsync(species);
            mapperMock.Setup(mapperMock => mapperMock.Map<IEnumerable<SpeciesDto>>(species))
                .Returns(speciesDtos);

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.Ok(speciesDtos);

            // Act
            var actualResponse = await speciesService.GetAllSpeciesAsync();

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task CreateSpeciesAsync_WhenSpeciesNameIsInvalid_ReturnsBadRequestResponse()
        {
            var speciesDto = new SpeciesDto { Name = "Cat1" };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.BadRequest<SpeciesDto>("You inserted incorrect letter in species name.");

            // Act
            var actualResponse = await speciesService.CreateSpeciesAsync(speciesDto);

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task CreateSpeciesAsync_WhenSpeciesNameIsValid_ReturnsCreatedResponse()
        {

            var speciesDto = new SpeciesDto { Name = "Cat" };
            var species = new Species { Name = "Cat" };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(unitOfWorkMock => unitOfWorkMock.Species.AddAsync(species))
                .ReturnsAsync(species);
            unitOfWorkMock.Setup(unitOfWorkMock => unitOfWorkMock.CommitAsync()).ReturnsAsync(1);
            mapperMock.Setup(mapperMock => mapperMock.Map<Species>(speciesDto)).Returns(species);

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.Created(speciesDto);

            // Act
            var actualResponse = await speciesService.CreateSpeciesAsync(speciesDto);

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task UpdateSpeciesByIdAsync_WhenSpeciesNameIsInvalid_ReturnsBadRequestResponse()
        {
            // Arrange
            var speciesDto = new SpeciesDto { Name = "Cat1" };
            int id = 1;

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.BadRequest<SpeciesDto>("You inserted incorrect letter in species name.");

            // Act
            var actualResponse = await speciesService.UpdateSpeciesByIdAsync(id, speciesDto);

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task UpdateSpeciesByIdAsync_WhenSpeciesNameIsValidAndSpeciesWithIdDoesNotExist_ReturnsNotFoundResponse()
        {
            // Arrange
            var speciesDto = new SpeciesDto { Name = "Cat" };
            Species species = null;
            int id = 1;

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(u => u.Species.GetByIdAsync(id)).ReturnsAsync(species);

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.NotFound<SpeciesDto>(id);

            // Act
            var actualResponse = await speciesService.UpdateSpeciesByIdAsync(id, speciesDto);

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task UpdateSpeciesByIdAsync_WhenSpeciesNameIsValidAndSpeciesWithIdExists_ReturnsOkResponse()
        {
            // Arrange
            var speciesDto = new SpeciesDto { Name = "Cat" };
            Species species = new Species { Id = 1, Name = "Dog" };
            int id = 1;

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(u => u.Species.GetByIdAsync(id)).ReturnsAsync(species);
            unitOfWorkMock.Setup(u => u.Species.Update(species)).Returns(species);
            unitOfWorkMock.Setup(u => u.CommitAsync()).ReturnsAsync(1);

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.Ok(speciesDto);

            // Act
            var actualResponse = await speciesService.UpdateSpeciesByIdAsync(id, speciesDto);

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task DeleteSpeciesByIdAsync_WhenSpeciesWithIdDoesNotExist_ReturnsNotFoundResponse()
        {
            // Arrange
            Species species = null;
            int id = 1;

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(unitOfWork => unitOfWork.Species.GetByIdAsync(id)).ReturnsAsync(species);

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.NotFound<SpeciesDto>(id);

            // Act
            var actualResponse = await speciesService.DeleteSpeciesByIdAsync(id);

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task DeleteSpeciesByIdAsync_WhenSpeciesWithIdExists_ReturnsNoContentResponse()
        {
            // Arrange
            Species species = new Species { Id = 1, Name = "Cat" };
            int id = 1;

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(unitOfWork => unitOfWork.Species.GetByIdAsync(id)).ReturnsAsync(species);
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.Species.Delete(species));
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.CommitAsync()).ReturnsAsync(1);

            var speciesService = new SpeciesService(unitOfWorkMock.Object, mapperMock.Object);

            var expectedResponse = ResponseFactory.NoContent<SpeciesDto>();

            // Act
            var actualResponse = await speciesService.DeleteSpeciesByIdAsync(id);

            // Assert
            Assert.Equal(expectedResponse, actualResponse);
        }
    }
}
