namespace VCMS.Core.ApiResponse
{
    /// <summary>
    /// Response class
    /// </summary>
    /// <typeparam name="T">
    /// Response data type
    /// </typeparam>
    public class Response<T> where T : class
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Response() { }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="isSucceeded">
        /// Succeeded or not
        /// </param>
        /// <param name="status">
        /// Response status code
        /// </param>
        /// <param name="data">
        /// Response data
        /// </param>
        /// <param name="message">
        /// Error message
        /// </param>
        public Response(bool isSucceeded, EResponseStatusCode status, T data, string message) 
        {
            IsSucceeded = isSucceeded;
            StatusCode = status;
            Data = data;
            Message = message;
        }

        /// <summary>
        /// Succeeded or not
        /// </summary>
        public bool IsSucceeded { get; set; }

        /// <summary>
        /// Response status code
        /// </summary>
        public EResponseStatusCode StatusCode { get; set; }

        /// <summary>
        /// Response data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }
    }
}
