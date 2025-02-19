using System.Runtime.InteropServices;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        //This is used when client request data in a unsuported format (Ex: requesting XML when endpoint only support JSON) through its accept headers. We return a 406 Not Acceptable response without returning data. Otherwise server returns data in the format server currently support ex: JSON  
        options.ReturnHttpNotAcceptable = true;
    }
).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters()
;
//Above line converts reponses to XML when requested by the client


//Integrate OpenAPI Endpoint
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
