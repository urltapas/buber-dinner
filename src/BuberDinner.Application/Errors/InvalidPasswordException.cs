using System.Net;
namespace BuberDinner.Application.Errors;

public class InvalidPasswordException : Exception
{
    public const string ErrorMessage = "Invalid password.";
    public static HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
