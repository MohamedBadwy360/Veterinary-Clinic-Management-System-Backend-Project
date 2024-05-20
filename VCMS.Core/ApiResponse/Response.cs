namespace VCMS.Core.ApiResponse
{
    public class Response<T> where T : class
    {
        public Response() { }
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

        
        public static Response<T> Failure(EResponseStatusCode status, string message)
        {
            return new Response<T>
            {
                IsSucceeded = false,
                StatusCode = status,
                Data = default,
                Message = message
            };
        }
        public static Response<T> Success(EResponseStatusCode status, T data)
        {
            return new Response<T>
            {
                IsSucceeded = true,
                StatusCode = status,
                Data = data,
                Message = default
            };
        }
    }
}
