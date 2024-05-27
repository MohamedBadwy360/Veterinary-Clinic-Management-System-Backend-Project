namespace VCMS.Core.ApiResponse;

public class ResponseFactory
{
    public static Response<T> CreateResponse<T>(EResponseStatusCode statusCode, T data = null,
        string message = null) where T : class
    {
        return new Response<T>
        {
            IsSucceeded = ((int)statusCode > 400) ? false : true,
            StatusCode = statusCode,
            Data = data,
            Message = message
        };
    }
    public static Response<T> NotFound<T>()
        where T : class
    {
        return Failure<T>(EResponseStatusCode.NotFound,
            $"No entities were found.");
    }
    public static Response<T> NotFound<T>(int id)
        where T : class
    {
        return Failure<T>(EResponseStatusCode.NotFound,
            $"Entity with Id {id} is not found.");
    }
    public static Response<T> Ok<T>(T data)
        where T : class
    {
        return Success(EResponseStatusCode.OK, data);
    }
    public static Response<T> Ok<T>()
        where T : class
    {
        return Success<T>(EResponseStatusCode.OK);
    }
    public static Response<T> Created<T>(T data)
        where T : class
    {
        return Success<T>(EResponseStatusCode.Created, data);
    }
    public static Response<T> Created<T>()
        where T : class
    {
        return Success<T>(EResponseStatusCode.Created);
    }
    public static Response<T> NoContent<T>()
        where T : class
    {
        return Success<T>(EResponseStatusCode.NoContent);
    }
    public static Response<T> BadRequest<T>(string message)
        where T : class
    {
        return Failure<T>(EResponseStatusCode.BadRequest, message);
    }
    public static Response<T> Conflict<T>(string message)
        where T : class
    {
        return Failure<T>(EResponseStatusCode.Conflict, message);
    }
    public static Response<T> InternalServerError<T>(string message) 
        where T : class
    {
        return Failure<T>(EResponseStatusCode.InternalServerError, message);
    }


    // ----------- Private -----------
    private static Response<T> Failure<T>(EResponseStatusCode status, string message)
        where T : class
    {
        return new Response<T>
        {
            IsSucceeded = false,
            StatusCode = status,
            Data = default,
            Message = message
        };
    }
    private static Response<T> Success<T>(EResponseStatusCode status, T data) 
        where T : class
    {
        return new Response<T>
        {
            IsSucceeded = true,
            StatusCode = status,
            Data = data,
            Message = default
        };
    }
    private static Response<T> Success<T>(EResponseStatusCode status)
        where T : class
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
