using OnionArch.Application;
using OnionArch.Infrastructure;
using OnionArch.Persistence;
using OnionArch.Persistence.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
builder.Logging.AddSerilog();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration.GetSection("Web")).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Configuration.GetValue<bool>("SeedData"))
{
    await app.FillDatabase();
}

app.UseAuthorization();
app.AutoMigrateDatabase();
app.MapControllers();

app.Run();
