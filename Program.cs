using System.Runtime.InteropServices;
using CityInfo;
using CityInfo.DbContexts;
using CityInfo.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    options =>
    {
        //This is used when client request data in an unsupported format (Ex: requesting XML when endpoint only support JSON) through its accept headers. We return a 406 Not Acceptable response without returning data. Otherwise server returns data in the format server currently support ex: JSON  
        options.ReturnHttpNotAcceptable = true;
    }
).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
//Above line converts responses to XML when requested by the client


//BY changing between debug and release modes in IDE we can define different mail services accordingly
#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif


//Adds CitiesDataStore as a singleton (Therefore we don't need to define static current variable (See CitiesDataStore)
builder.Services.AddSingleton<CitiesDataStore>();

builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Integrate CityInfoContext. Uses scoped lifetime
builder.Services.AddDbContext<CityInfoContext>
    (dbContextOptions => 
        dbContextOptions.UseSqlite(
            builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"])
     );



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
