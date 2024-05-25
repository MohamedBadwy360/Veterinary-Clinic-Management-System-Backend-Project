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

    
        public static Response<T> NotFound()
        {
            return Failure(EResponseStatusCode.NotFound,
                $"No entities were found.");
        }
        public static Response<T> NotFound(int id)
        {
            return Failure(EResponseStatusCode.NotFound,
                $"Entity with Id {id} is not found.");
        }
        public static Response<T> Ok(T data)
        {
            return Success(EResponseStatusCode.OK, data);
        }
        public static Response<T> Ok()
        {
            return Success(EResponseStatusCode.OK);
        }
        public static Response<T> Created(T data)
        {
            return Success(EResponseStatusCode.Created, data);
        }
        public static Response<T> Created()
        {
            return Success(EResponseStatusCode.Created);
        }
        public static Response<T> NoContent()
        {
            return Success(EResponseStatusCode.NoContent);
        }
        public static Response<T> BadRequest(string message)
        {
            return Failure(EResponseStatusCode.BadRequest, message);
        }
        public static Response<T> Conflict(string message)
        {
            return Failure(EResponseStatusCode.Conflict, message);
        }
        public static Response<T> InternalServerError(string message)
        {
            return Failure(EResponseStatusCode.InternalServerError, message);
        }


        // ----------- Private -----------
        private static Response<T> Failure(EResponseStatusCode status, string message)
        {
            return new Response<T>
            {
                IsSucceeded = false,
                StatusCode = status,
                Data = default,
                Message = message
            };
        }
        private static Response<T> Success(EResponseStatusCode status, T data)
        {
            return new Response<T>
            {
                IsSucceeded = true,
                StatusCode = status,
                Data = data,
                Message = default
            };
        }
        private static Response<T> Success(EResponseStatusCode status)
        {
            return new Response<T>
            {
                IsSucceeded = true,
                StatusCode = status,
                Data = default,
                Message = default
            };
        }
    }
}
