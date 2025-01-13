using System.Net;

namespace Hotel.Application.Exceptions;

public abstract class HttpStatusException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}