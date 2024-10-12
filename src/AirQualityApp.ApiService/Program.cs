using AirQualityApp.ApiService.Internal;
using AirQualityApp.ApiService.Models;
using AirQualityApp.ApiService.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddTransient<IAirQualityReportRepository, SqliteAirQualityReportsDbContext>();
builder.Services.AddSingleton<ICsvReaderService<AirQualityReport>, CsvReaderService<AirQualityReport>>();
builder.Services.AddTransient<IAirQualityProcessorService<IAirQualityReportRepository, ICsvReaderService<AirQualityReport>>, AirQualityProcessorService<IAirQualityReportRepository, ICsvReaderService<AirQualityReport>>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

// Use the service where necessary (optional, depending on how your app uses it)
app.MapGet("/", (IAirQualityProcessorService<IAirQualityReportRepository, ICsvReaderService<AirQualityReport>> processorService) =>
{
    processorService.PrintDataOnScreen();

    return Results.Ok();
});

app.MapDefaultEndpoints();



app.Run();
