using System.Net;

namespace Hotel.Application.Exceptions;

public class BadRequestException(string message) : HttpStatusException(HttpStatusCode.BadRequest, message)
{
}