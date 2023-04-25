using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetMarket.Core.Interfaces.Services;
using NetMarket.Core.Services.Mocks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductService, MockProductService>();

builder.Services.AddControllers();

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

app.MapControllers();

app.Run();
