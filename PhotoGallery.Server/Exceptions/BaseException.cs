using System.Net;
using PhotoGallery.Server.Enums;

namespace PhotoGallery.Server.Exceptions;

public class BaseException: Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public ErrorCode ErrorCode { get; set; }

    public BaseException(string message, HttpStatusCode statusCode, ErrorCode errorCode)
        : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
}