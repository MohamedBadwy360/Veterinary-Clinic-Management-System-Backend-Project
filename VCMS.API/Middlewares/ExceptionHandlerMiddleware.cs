namespace VCMS.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DbUpdateException exception)
            {
                // Logging will be here .....
                await HandleDatabaseUpdateExceptionAsync(httpContext, exception);
            }
            catch (Exception exception)
            {
                // Logging will be here .....
                await HandleGenericException(httpContext, exception);
            }
        }


        private static Task HandleDatabaseUpdateExceptionAsync(HttpContext httpContext, DbUpdateException exception)
        {
            if (exception.InnerException is SqlException sqlException &&
                    sqlException.Number == SqlServerErrorNumbers.ViolateUniqueConstraint)
            {
                httpContext.Response.StatusCode = StatusCodes.Status409Conflict;

                var response = ResponseFactory.Create<object>(EResponseStatusCode.Conflict,
                    message: "A database update error occurred because an entity with same data exists.");

                return httpContext.Response.WriteAsJsonAsync(response);
            }
            else
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = ResponseFactory.Create<object>(EResponseStatusCode.InternalServerError,
                    message: "A database error occurred.");

                return httpContext.Response.WriteAsJsonAsync(response);
            }
        }

        private static Task HandleGenericException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = ResponseFactory.Create<object>(EResponseStatusCode.InternalServerError,
                message: "An unexpected error occurred.");

            return httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
