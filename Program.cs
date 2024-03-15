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

using Demo.Middleware.CustomMiddleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello!\n");
    await next(context);
});

//middleware 2
//app.Use(async (HttpContext context, RequestDelegate next) => {
//    await context.Response.WriteAsync("Android");
//    await next(context);
//});

//middleware 2
//app.UseMiddleware<CustomMiddleware>();
app.UseCm();

//middleware 3
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Coding!!\n");
});

app.Run();