namespace VCMS.Core.ApiResponse;

/// <summary>
/// Factory class to create response objects.
/// </summary>
public class ResponseFactory
{
    /// <summary>
    /// Creates a response object with the given status code, data and message.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="statusCode">
    /// The status code of the response.
    /// </param>
    /// <param name="data">
    /// The data object to be returned.
    /// </param>
    /// <param name="message">
    /// The message to be returned.
    /// </param>
    /// <returns>
    /// A response object with the given status code, data and message.
    /// </returns>
    public static Response<T> Create<T>(EResponseStatusCode statusCode, T data = null,
        string message = null) where T : class
    {
        return new Response<T>
        {
            IsSucceeded = ((int)statusCode >= 400) ? false : true,
            StatusCode = statusCode,
            Data = data,
            Message = message
        };
    }

    /// <summary>
    /// Creates a response object with 404 status code and the given message.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <returns>
    /// A response object with 404 status code and the given message.
    /// </returns>
    public static Response<T> NotFound<T>()
        where T : class
    {
        return Failure<T>(EResponseStatusCode.NotFound,
            $"No entities were found.");
    }

    /// <summary>
    /// Creates a response object with 404 status code and the given message.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="id">
    /// The id of the entity that is not found.
    /// </param>
    /// <returns>
    /// A response object with 404 status code and the given message.
    /// </returns>
    public static Response<T> NotFound<T>(int id)
        where T : class
    {
        return Failure<T>(EResponseStatusCode.NotFound,
            $"Entity with Id {id} is not found.");
    }

    /// <summary>
    /// Creates a response object with 404 status code and the given message.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="message">
    /// The message to be returned.
    /// </param>
    /// <returns>
    /// A response object with 404 status code and the given message.
    /// </returns>
    public static Response<T> NotFound<T>(string message)
        where T : class
    {
        return Failure<T>(EResponseStatusCode.NotFound, message);
    }

    /// <summary>
    /// Creates a response object with 200 status code and the given data.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="data">
    /// The data object to be returned.
    /// </param>
    /// <returns>
    /// A response object with 200 status code and the given data.
    /// </returns>
    public static Response<T> Ok<T>(T data)
        where T : class
    {
        return Success(EResponseStatusCode.OK, data);
    }

    /// <summary>
    /// Creates a response object with 200 status code and no data.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <returns>
    /// A response object with 200 status code and no data.
    /// </returns>
    public static Response<T> Ok<T>()
        where T : class
    {
        return Success<T>(EResponseStatusCode.OK);
    }

    /// <summary>
    /// Creates a response object with 201 status code and the given data.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="data">
    /// The data object to be returned.
    /// </param>
    /// <returns>
    /// A response object with 201 status code and the given data.
    /// </returns>
    public static Response<T> Created<T>(T data)
        where T : class
    {
        return Success<T>(EResponseStatusCode.Created, data);
    }

    /// <summary>
    /// Creates a response object with 201 status code and no data.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <returns>
    /// A response object with 201 status code and no data.
    /// </returns>
    public static Response<T> Created<T>()
        where T : class
    {
        return Success<T>(EResponseStatusCode.Created);
    }

    /// <summary>
    /// Creates a response object with 204 status code and no data.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <returns>
    /// A response object with 204 status code and no data.
    /// </returns>
    public static Response<T> NoContent<T>()
        where T : class
    {
        return Success<T>(EResponseStatusCode.NoContent);
    }

    /// <summary>
    /// Creates a response object with 400 status code and the given message.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="message">
    /// The message to be returned.
    /// </param>
    /// <returns>
    /// A response object with 400 status code and the given message.
    /// </returns>
    public static Response<T> BadRequest<T>(string message)
        where T : class
    {
        return Failure<T>(EResponseStatusCode.BadRequest, message);
    }

    /// <summary>
    /// Creates a response object with 409 status code and the given message.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="message">
    /// The message to be returned.
    /// </param>
    /// <returns>
    /// A response object with 409 status code and the given message.
    /// </returns>
    public static Response<T> BadRequest<T>(T data, string message)
        where T : class
    {
        return Create<T>(EResponseStatusCode.BadRequest, data, message);
    }

    public static Response<T> Conflict<T>(string message)
        where T : class
    {
        return Failure<T>(EResponseStatusCode.Conflict, message);
    }

    /// <summary>
    /// Creates a response object with 500 status code and the given message.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="message">
    /// The message to be returned.
    /// </param>
    /// <returns>
    /// A response object with 500 status code and the given message.
    /// </returns>
    public static Response<T> InternalServerError<T>(string message) 
        where T : class
    {
        return Failure<T>(EResponseStatusCode.InternalServerError, message);
    }


    // ----------- Private -----------

    /// <summary>
    /// Creates a failure response object with the given status code, data and message.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="status">
    /// The status code of the response.
    /// </param>
    /// <param name="message">
    /// The message to be returned.
    /// </param>
    /// <returns>
    /// A failure response object with the given status code, data and message.
    /// </returns>
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

    /// <summary>
    /// Creates a success response object with the given status code and data.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="status">
    /// The status code of the response.
    /// </param>
    /// <param name="data">
    /// The data object to be returned.
    /// </param>
    /// <returns>
    /// A success response object with the given status code and data.
    /// </returns>
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

    /// <summary>
    /// Creates a success response object with the given status code and no data.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data object.
    /// </typeparam>
    /// <param name="status">
    /// The status code of the response.
    /// </param>
    /// <returns>
    /// A success response object with the given status code and no data.
    /// </returns>
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
