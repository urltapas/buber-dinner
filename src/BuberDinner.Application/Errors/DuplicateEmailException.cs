using System.Net;

namespace BuberDinner.Application.Errors;

public class DuplicateEmailException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;
    public static string ErrorMessage => "Email already exists";
}