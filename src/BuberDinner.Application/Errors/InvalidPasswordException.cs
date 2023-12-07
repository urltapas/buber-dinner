namespace BuberDinner.Application.Errors;

public class InvalidPasswordException : Exception, IServiceException
{
    public string ErrorMessage => "Invalid password.";
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}