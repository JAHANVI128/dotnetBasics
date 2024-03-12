var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if( 1 == 2)
    {
        context.Response.StatusCode = 500;
    } else
    {
        context.Response.StatusCode = 200;
    }
    await context.Response.WriteAsync("hii");
    await context.Response.WriteAsync(" Jahanvi here");
});

app.Run();
