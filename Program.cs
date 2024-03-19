//using Microsoft.Extensions.Primitives;
//using System.IO;

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.Run(async (HttpContext context) =>
//{
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
//context.Response.Headers["Content-type"] = "text/html";
//if (context.Request.Headers.ContainsKey("User-Agent")) {
//    string userAgent = context.Request.Headers["User-Agent"];
//    await context.Response.WriteAsync($"<p>User-Agent: {userAgent}</p>");
//} 

/*if(context.Request.Method == "POST") {
        string name = context.Request.Form["name"];
        string email = context.Request.Form["email"];
        await context.Response.WriteAsync($"Name: {name}");
        await context.Response.WriteAsync($"Email: {email}");
    } else {
        await context.Response.WriteAsync("Hello World!");
    }*/
//if(context.Request.Method == "GET") {
//string name = context.Request.Query["name"];
//string email = context.Request.Query["email"];
//await context.Response.WriteAsync($"Name: {name}");
//await context.Response.WriteAsync($"Email: {email}");
//    if(context.Request.Query.ContainsKey("id")) {
//        string id = context.Request.Query["id"];
//        await context.Response.WriteAsync($"ID : {id}");
//    } else {
//        await context.Response.WriteAsync("ID not found");
//    }
//}
//else {
//    await context.Response.WriteAsync("Hello World!");
//}

//GET POST
//StreamReader reader = new StreamReader(context.Request.Body);
//string body = await reader.ReadToEndAsync();
//Dictionary<string, StringValues> queryDict =  Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

//if (queryDict.ContainsKey("firstName"))
//{
//    string firstName = queryDict["firstName"][0];
//    await context.Response.WriteAsync(firstName);
//}
//if (body == "Jahanvi here")
//{
//    context.Response.StatusCode = 200;
//} else
//{
//    context.Response.StatusCode = 500;
//}
//});

//app.Run();

/*Math app through HTTP GET

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Terminating middleware
app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET" && context.Request.Path == "/")
    {
        int firstNumber = 0, secondNumber = 0;
        string? operation = null;
        long? result = null;

        //read 'firstNumber' if submitted in the request body
        if (context.Request.Query.ContainsKey("firstNumber"))
        {
            string firstNumberString = context.Request.Query["firstNumber"][0];
            if (!string.IsNullOrEmpty(firstNumberString))
            {
                firstNumber = Convert.ToInt32(firstNumberString);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
            }
        }
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
        }

        //read 'secondNumber' if submitted in the request body
        if (context.Request.Query.ContainsKey("secondNumber"))
        {
            string secondNumberString = context.Request.Query["secondNumber"][0];
            if (!string.IsNullOrEmpty(secondNumberString))
            {
                secondNumber = Convert.ToInt32(context.Request.Query["secondNumber"][0]);
            }
            else
            {
                if (context.Response.StatusCode == 200)
                    context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
            }
        }
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
        }

        //read 'operation' if submitted in the request body
        if (context.Request.Query.ContainsKey("operation"))
        {
            operation = Convert.ToString(context.Request.Query["operation"][0]);

            //perform the calculation based on the value of "operation"
            switch (operation)
            {
                case "add": result = firstNumber + secondNumber; break;
                case "subtract": result = firstNumber - secondNumber; break;
                case "multiply": result = firstNumber * secondNumber; break;
                case "divide": result = (secondNumber != 0) ? firstNumber / secondNumber : 0; break; //avoid DivideByZeroException, if secondNuber is 0 (zero)
                case "mod": result = (secondNumber != 0) ? firstNumber % secondNumber : 0; break; //avoid DivideByZeroException, if secondNuber is 0 (zero)
            }

            //If no case matched above, the "result" remains as 'null'
            if (result.HasValue)
            {
                await context.Response.WriteAsync(result.Value.ToString());
            }

            //if invalid value is submitted for "operation" parameter
            else
            {
                if (context.Response.StatusCode == 200)
                    context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'operation'\n");
            }

        } //end of "of ContainsKey("operation")

        //if the "operation" parameter is submitted from the client
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'operation'\n");
        }
    }
});

app.Run();

*/

//using Demo.Middleware;
//using Demo.Middleware.Middleware.CustomMiddleware;
//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<CustomMiddleware>();
//var app = builder.Build();

//middleware 1
//app.Use(async (HttpContext context, RequestDelegate next) => {
//    await context.Response.WriteAsync("Hello!\n");
//    await next(context);
//});

//middleware 2
//app.Use(async (HttpContext context, RequestDelegate next) => {
//    await context.Response.WriteAsync("Android");
//    await next(context);
//});

//middleware 2
//app.UseMiddleware<CustomMiddleware>();
//app.UseCm();
//app.UseCMiddleware();

//middleware 3
//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Coding!!\n");
//});

//app.Run();



//UseWhen
//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.UseWhen(
//    context => context.Request.Query.ContainsKey("name"),
//    app => {
//        app.Use(async (context, next) =>
//        {
//            await context.Response.WriteAsync("UseWhen ");
//            await next();
//        });
//    }
//);

//app.Run(async context => {
//    await context.Response.WriteAsync("Hello World!");
//});

//app.Run(); 


//Create an Asp.Net Core Web Application that receives username and password via POST request (from Postman).

//using Demo.Middleware;

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

////Invoking custom middleware
//app.UseLoginMiddleware();

//app.Run(async context => {
//    await context.Response.WriteAsync("No response");
//});
//app.Run();


//Routing

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
//    if (endpoint != null) {
//        await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName }\n");
//    }
//    await next(context);
//});

app.UseRouting();

//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
//    if (endpoint != null)
//    {
//        await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
//    }
//    await next(context);
//});

app.UseEndpoints(endpoints => {
    //endpoints.Map("map1", async (context) => {
    //    await context.Response.WriteAsync("Map1");
    //});

    //endpoints.Map("map2", async (context) => {
    //    await context.Response.WriteAsync("Map2");
    //});

    endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
        //string filename = context.Request.RouteValues["filename"] as string;
        //string extension = context.Request.RouteValues["extension"] as string;
        //await context.Response.WriteAsync($"Filename: {filename}\n");
        //await context.Response.WriteAsync($"Extension: {extension}\n");

        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"Files - {filename} - {extension}");
    });

    endpoints.Map("employee/profile/{Id = 46}", async context => {
        string? id = Convert.ToString(context.Request.RouteValues["Id"]);
        await context.Response.WriteAsync($"Employee Profile - {id}");
    });

    endpoints.Map("products/details/{id=2}", async context =>
    {
        int pid = Convert.ToInt32(context.Request.RouteValues.["id"]);
        await context.Response.WriteAsync($"Product ID: {pid}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request Received at {context.Request.Path}");
});

app.Run();