using Mapper;
using ZZGG.BusinessLogic;
using ZZGG.BusinessLogic.Interfaces;
using ZZGG.Services;
using ZZGG.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAccountBusinessLogic, AccountBusinessLogic>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddAutoMapper(typeof(DefaultProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
