namespace VCMS.API.Extensions
{
    public static class MiddlewaresExtensions
    {
        /// <summary>
        /// A method to use the exception handler middleware
        /// </summary>
        /// <param name="app">
        /// The application builder.
        /// </param>
        /// <returns>
        /// The application builder with the exception handler middleware added to the pipeline.
        /// </returns>
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
