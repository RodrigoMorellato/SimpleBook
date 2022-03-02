using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleBookApi.Initializer;
using SimpleBookApi.Repositories.Configuration;
using SimpleBookApi.Swagger;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Add and activate ILogger
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "SimpleBookApi",
            Description = "API management books",
            Version = "v1"
        });
    c.SchemaFilter<SwaggerSchemaExampleFilter>();
    c.UseInlineDefinitionsForEnums();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

Initializer.Configure(builder.Services);
// Add test data to the repository
var options = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase("LibraryDb").Options;
Initializer.AddTestData(options);

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
