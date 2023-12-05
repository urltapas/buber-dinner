using System.Net;
namespace BuberDinner.Application.Errors;

public class EmailGivenNotFoundException : Exception
{
    public static HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public static string ErrorMessage => "Email Given User Not Found";
}
