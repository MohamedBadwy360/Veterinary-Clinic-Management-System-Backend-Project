namespace VCMS.Core.Enums
{
    /// <summary>
    /// Enum for response status codes
    /// </summary>
    public enum EResponseStatusCode
    {
        OK = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        InternalServerError = 500
    }
}
