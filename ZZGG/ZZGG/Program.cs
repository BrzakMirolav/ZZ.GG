using Mapper;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json.Serialization;
using ZZGG.BusinessLogic;
using ZZGG.BusinessLogic.Interfaces;
using ZZGG.Services;
using ZZGG.Services.Interfaces;

using MvcJsonOptions = Microsoft.AspNetCore.Mvc.JsonOptions;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using Microsoft.Extensions.Configuration;
using Serilog.Debugging;

var builder = WebApplication.CreateBuilder(args);
var _config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: true)
        .Build();

// Add services to the container.

Log.Logger = new LoggerConfiguration()
.Enrich.FromLogContext()
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", LogEventLevel.Error)
.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
.MinimumLevel.Override("Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware", LogEventLevel.Information)
.Enrich.WithMachineName()
.Enrich.WithCorrelationIdHeader()
.Enrich.WithEnvironmentName()
.WriteTo.File("Logs\\Log.txt", rollingInterval: RollingInterval.Day)
.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("https://elastic:ek2022!187@localhost:9200"))
{
    //ModifyConnectionSettings = x => x.BasicAuthentication("elastic", "your-password"),
    ModifyConnectionSettings = configuration => configuration.ServerCertificateValidationCallback(
                        (o, certificate, arg3, arg4) => { return true; }),
    TypeName = null,
    AutoRegisterTemplate = true,
    IndexFormat = _config["ApplicationName"],

})
.ReadFrom.Configuration(_config)
.CreateLogger();

SelfLog.Enable(Console.Error);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);
builder.Host.UseSerilog(Log.Logger);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>{

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlPath);

});

builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.Configure<MvcJsonOptions>(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddScoped<IAccountBusinessLogic, AccountBusinessLogic>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddAutoMapper(typeof(DefaultProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.

Log.Information("ZZGG API Started. Application name: " + _config["ApplicationName"]);

app.UseSerilogRequestLogging();
app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
