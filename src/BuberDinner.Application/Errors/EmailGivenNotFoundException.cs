﻿namespace BuberDinner.Application.Errors;

public class EmailGivenNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "Email given not found";
}