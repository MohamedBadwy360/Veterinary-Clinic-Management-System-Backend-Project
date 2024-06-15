namespace VCMS.Tests.VCMS.Core.Tests.ApiResponse
{
    public class ResponseFactoryTests
    {
        [Fact]
        public void Create_WhenPassingStatusCodeLessThan400AndDataAndMessage_ShouldReturnResponseObjectWithIsSucceededEqualTrue()
        {
            // Arrange
            var statusCode = EResponseStatusCode.OK;
            var data = new { Id = 1, Name = "Test" };
            string message = null;
            var isSucceeded = true;

            // Act
            var response = ResponseFactory.Create(statusCode, data, message);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(isSucceeded, response.IsSucceeded);
            Assert.Equal(statusCode, response.StatusCode);
            Assert.Equal(data, response.Data);
            Assert.Equal(message, response.Message);
        }

        [Fact]
        public void Create_WhenPassingStatusCodeGreaterThan400AndDataAndMessage_ShouldReturnResponseObjectWithIsSucceededEqualFalse()
        {
            // Arrange
            var statusCode = EResponseStatusCode.BadRequest;
            var data = new { Id = 1, Name = "Test" };
            string message = "Test message";
            var isSucceeded = false;

            // Act
            var response = ResponseFactory.Create(statusCode, data, message);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(isSucceeded, response.IsSucceeded);
            Assert.Equal(statusCode, response.StatusCode);
            Assert.Equal(data, response.Data);
            Assert.Equal(message, response.Message);
        }

        [Fact]
        public void Create_WhenPassingStatusCodeLessThan400_ShouldReturnResponseObjectWithIsSucceededEqualTrueAndDataIsNullAndMessageIsNull()
        {
            // Arrange
            var statusCode = EResponseStatusCode.NoContent;

            // Act
            var response = ResponseFactory.Create<object>(statusCode);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSucceeded);
            Assert.Equal(statusCode, response.StatusCode);
            Assert.Null(response.Data);
            Assert.Null(response.Message);
        }

        [Fact]
        public void NotFound_NoParameters_ReturnsExpectedResponse()
        {
            // Arrange
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.NotFound;
            const string expectedMessage = "No entities were found.";

            // Act
            var response = ResponseFactory.NotFound<object>();

            // Assert
            Assert.NotNull(response);
            Assert.False(response.IsSucceeded);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Null(response.Data);
            Assert.Equal(expectedMessage, response.Message);
        }

        [Fact]
        public void NotFound_WithId_ReturnsExpectedResponse()
        {
            // Arrange
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.NotFound;
            var id = 5;
            string expectedMessage = $"Entity with Id {id} is not found.";

            // Act
            var response = ResponseFactory.NotFound<object>(id);

            // Assert
            Assert.NotNull(response);
            Assert.False(response.IsSucceeded);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Null(response.Data);
            Assert.Equal(expectedMessage, response.Message);
        }

        [Fact]
        public void NotFound_WithMessage_ReturnsExpectedResponse()
        {
            // Arrange
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.NotFound;
            const string expectedMessage = "Test message";

            // Act
            var response = ResponseFactory.NotFound<object>(expectedMessage);

            // Assert
            Assert.NotNull(response);
            Assert.False(response.IsSucceeded);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Null(response.Data);
            Assert.Equal(expectedMessage, response.Message);
        }

        [Fact]
        public void Ok_WithData_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.OK;
            var expectedData = new { Id = 1, Name = "Mohamed" };

            // Act
            var response = ResponseFactory.Ok(expectedData);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSucceeded);
            Assert.Equal(expectedData, response.Data);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Null(response.Message);
        }

        [Fact]
        public void Ok_NoParameters_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.OK;

            // Act
            var response = ResponseFactory.Ok<object>();

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Response<object>>(response);
            Assert.True(response.IsSucceeded);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Null(response.Data);
            Assert.Null(response.Message);
        }

        [Fact]
        public void Created_WithData_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.Created;
            var expectedData = new { Id = 1, Name = "Mohamed" };

            // Act
            var response = ResponseFactory.Created(expectedData);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSucceeded);
            Assert.Equal(expectedData, response.Data);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Null(response.Message);
        }

        [Fact]
        public void Created_NoParameters_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.Created;

            // Act
            var response = ResponseFactory.Created<object>();

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSucceeded);
            Assert.Null(response.Data);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Null(response.Message);
        }

        [Fact]
        public void NoContent_WhenCalled_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.NoContent;

            // Act
            var response = ResponseFactory.NoContent<object>();

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSucceeded);
            Assert.Null(response.Data);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Null(response.Message);
        }

        [Fact]
        public void BadRequest_WithMessage_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.BadRequest;
            const string expectedMessage = "Test Message";

            // Act
            var response = ResponseFactory.BadRequest<object>(expectedMessage);

            // Assert
            Assert.NotNull(response);
            Assert.False(response.IsSucceeded);
            Assert.Null(response.Data);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.Message);
        }

        [Fact]
        public void BadRequest_WithDataAndMessage_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.BadRequest;
            const string expectedMessage = "Test Message";
            var expectedData = new { Id = 1, Name = "Mohamed" };

            // Act
            var response = ResponseFactory.BadRequest<object>(expectedData, expectedMessage);

            // Assert
            Assert.NotNull(response);
            Assert.False(response.IsSucceeded);
            Assert.Equal(expectedData, response.Data);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.Message);
        }

        [Fact]
        public void Conflict_WithMessage_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.Conflict;
            const string expectedMessage = "Test Message";

            // Act
            var response = ResponseFactory.Conflict<object>(expectedMessage);

            // Assert
            Assert.NotNull(response);
            Assert.False(response.IsSucceeded);
            Assert.Null(response.Data);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.Message);
        }

        [Fact]
        public void InternalServerError_WithMessage_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.InternalServerError;
            const string expectedMessage = "Test Message";

            // Act
            var response = ResponseFactory.InternalServerError<object>(expectedMessage);

            // Assert
            Assert.NotNull(response);
            Assert.False(response.IsSucceeded);
            Assert.Null(response.Data);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.Message);
        }

        [Fact]
        public void Failure_WithStatusCodeAndMessage_ReturnsExpectedResponse()
        {
            // Arrange 
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.BadRequest;
            const string expectedMessage = "Test Message";

            MethodInfo? methodDefinition = typeof(ResponseFactory).GetMethod("Failure",
                BindingFlags.NonPublic | BindingFlags.Static, null, 
                new Type[] { typeof(EResponseStatusCode), typeof(string) }, null);

            MethodInfo? method = methodDefinition?.MakeGenericMethod(typeof(object));
            // Act
            
            var actualResponse = method?.Invoke(null, new object[] { expectedStatusCode, expectedMessage }) as Response<object>;

            // Assert
            Assert.NotNull(actualResponse);
            Assert.False(actualResponse.IsSucceeded);
            Assert.Null(actualResponse.Data);
            Assert.Equal(expectedStatusCode, actualResponse.StatusCode);
            Assert.Equal(expectedMessage, actualResponse.Message);
        }

        [Fact]
        public void Success_WithStatusCode_ReturnsExpectedResponse()
        {
            // Arrange
            const EResponseStatusCode expectedStatusCode = EResponseStatusCode.OK;

            MethodInfo? methodDefinition = typeof(ResponseFactory).GetMethod("Success",
                BindingFlags.NonPublic | BindingFlags.Static, null,
                new Type[] { typeof(EResponseStatusCode) }, null);

            MethodInfo? method = methodDefinition?.MakeGenericMethod(typeof(object));

            // Act
            var response = method?.Invoke(null, new object[] { expectedStatusCode }) as Response<object>;

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSucceeded);
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Null(response.Data);
            Assert.Null(response.Message);
        }
    }
}
