var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    /* if( 1 == 2) {
            context.response.statuscode = 500;
        } else {
            context.response.statuscode = 200;
        }*/

    //Response Headers
    //context.Response.Headers["name"] = "jahanvi";
    //context.Response.Headers["Server"] = "Django";
    //context.Response.Headers["Content-type"] = "text/html";

    //await context.Response.WriteAsync("<h1>Hii</h1>");
    //await context.Response.WriteAsync(" <h2>Jahanvi here</h2>");

    /* Request Headers
    string path = context.Request.Path;
    string method = context.Request.Method;

    context.Response.Headers["Content-type"] = "text/html";
    await context.Response.WriteAsync($"Path: {path}");
    await context.Response.WriteAsync($"Method: {method}");*/

    // Query String
    context.Response.Headers["Content-type"] = "text/html";

    /*if(context.Request.Method == "POST") {
            string name = context.Request.Form["name"];
            string email = context.Request.Form["email"];
            await context.Response.WriteAsync($"Name: {name}");
            await context.Response.WriteAsync($"Email: {email}");
        } else {
            await context.Response.WriteAsync("Hello World!");
        }*/
    if(context.Request.Method == "GET") {
        //string name = context.Request.Query["name"];
        //string email = context.Request.Query["email"];
        //await context.Response.WriteAsync($"Name: {name}");
        //await context.Response.WriteAsync($"Email: {email}");
        if(context.Request.Query.ContainsKey("id")) {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"ID : {id}");
        } else {
            await context.Response.WriteAsync("ID not found");
        }
    }
    else {
        await context.Response.WriteAsync("Hello World!");
    }
});

app.Run();
