using BuberDinner.API;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    // app.Map("/error", (HttpContext context) =>
    // {
    //     Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    //     return Results.Problem(title: exception?.Message, statusCode: 500);
    // });

    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run();
}