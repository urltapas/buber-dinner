using System.Net;
namespace BuberDinner.Application;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}
