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

        /// <summary>
        /// Equals method override for Response class.
        /// </summary>
        /// <param name="obj">
        /// The object to compare with the current object.
        /// </param>
        /// <returns>
        /// True if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Response<T> response &&
                IsSucceeded == response.IsSucceeded &&
                StatusCode == response.StatusCode &&
                EqualityComparer<T>.Default.Equals(Data, response.Data) &&
                Message == response.Message;
        }

        /// <summary>
        /// GetHashCode method override for Response class.
        /// </summary>
        /// <returns>
        /// Hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(IsSucceeded, StatusCode, Data, Message);
        } 
    }
}
