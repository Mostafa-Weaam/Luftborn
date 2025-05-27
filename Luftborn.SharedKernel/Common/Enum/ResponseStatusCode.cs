namespace Luftborn.SharedKernel.Common.Enum
{
    public enum ResponseStatusCode
    {
        Successfully = 200, // OK

        NotFound = 404, // Not Found

        NotAccept = 406, // Not Acceptable

        MultiError = 400, // Bad Request

        MoveNotAccept = 400, // Bad Request

        SystemInternalError = 500, // Internal Server Error

        Dublicate = 409, // Conflict

        InvalidData = 422, // Unprocessable Entity

        DeleteNotAccept = 409, // Conflict

        FailedSendSMS = 503, // Service Unavailable

        InvalidAzureADToken = 401, // Unauthorized

        IntegrationError = 502, // Bad Gateway

        NotAuthorized = 401, // Forbidden

        AlreadyExists = 409, // Conflict

        IsLockedOut = 423, // Locked

        PasswordNotMatch = 401 // Unauthorized
    }
}
