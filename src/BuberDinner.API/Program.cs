var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();
    builder.Services.AddControllers();
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