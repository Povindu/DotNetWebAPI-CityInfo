using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();




// builder.Services.AddProblemDetails(options =>
// {
//     options.CustomizeProblemDetails = ctx =>
//     {
//         ctx.ProblemDetails.Extensions.Add("Additional Info", "Sample Info");
//         ctx.ProblemDetails.Extensions.Add("Server", Environment.MachineName);

//     };
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// app.UseRouting(); //Both can be replaced by new app.MapController

app.UseAuthorization();

// app.UseEndpoints(endpoints => {
//     endpoints.MapControllers();
// }); //Both can be replaced by new app.MapController

app.MapControllers();
app.MapScalarApiReference();

// app.MapGet("/", () => "Hello world!");

app.Run();
