using CQRSExample.Application.Extensions;
using CQRSExample.Persistance.Context;
using CQRSExample.Persistance.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Register Configuration
//ConfigurationManager configuration = builder.Configuration;


//Register Configuration
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer();

// Add services to the container
builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionString"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Product.API", Version = "v2" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "Product.API v2"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();




