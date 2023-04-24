using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//#if DEBUG
//    builder.Services.AddCors(options =>
//    {
//        options.AddDefaultPolicy(policy =>
//        {
//            policy.AllowAnyOrigin();
//        });
//    });
//#endif

var app = builder.Build();

//#if DEBUG
//    app.UseCors();
//#endif

// Prevent use http://*:5044
app.UseHttpsRedirection();

app.MapGet("/helloworld", () => "Hello World!");

app.MapGet("/connections/{name}", async (string name, IConfiguration configuration) =>
{
    return Results.Ok(new { connectionString = configuration.GetConnectionString(name) });
}).RequireAuthorization();

app.Run();
