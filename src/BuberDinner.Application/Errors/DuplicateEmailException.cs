using System.Net;
namespace BuberDinner.Application.Errors;

public class DuplicateEmailException : Exception
{
    public static HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public const string ErrorMessage = "Email already exists";
}