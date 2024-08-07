using OnionArch.Api;
using OnionArch.Application;
using OnionArch.Infrastructure;
using OnionArch.Persistence;
using OnionArch.Persistence.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.AddSwaggerWithAuth();

//Envoriment
var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

//Logger
builder.Logging.AddSerilog();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration.GetSection("Web")).CreateLogger();
builder.Host.UseSerilog();

//Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Authentication
builder.ConfigureAuthentication();

//Registration
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

//Enable CORS
app.UseCors(options =>
    options.SetIsOriginAllowed(origin => true).AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
);

app.UseAuthentication();
app.UseAuthorization();
app.AutoMigrateDatabase();
app.MapControllers();

app.Run();
