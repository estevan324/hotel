using System.Net;

namespace Hotel.Application.Exceptions;

public class NotFoundException(string message) : HttpStatusException(HttpStatusCode.NotFound, message)
{
}