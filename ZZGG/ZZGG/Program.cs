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

var builder = WebApplication.CreateBuilder(args);
var _config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

// Add services to the container.

Log.Logger = new LoggerConfiguration()
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
.WriteTo.File("Logs\\Log.txt", rollingInterval: RollingInterval.Day)
.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("https://elastic:ek2022!187@localhost:9200"))
{
    //ModifyConnectionSettings = x => x.BasicAuthentication("elastic", "your-password"),
     AutoRegisterTemplate = true,
     IndexFormat = _config["ApplicationName"],
     TypeName = null
})
.ReadFrom.Configuration(_config)
.CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);

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

//app.UseSerilogRequestLogging();

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
