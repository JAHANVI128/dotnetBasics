namespace Demo.Middleware.CustomMiddleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //throw new NotImplementedException();

            await context.Response.WriteAsync("Hello from custom middleware\n");
            await next(context);
            await context.Response.WriteAsync("Hello from custom middleware response\n");
        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCm(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
