using ExternalWebhookReceiverAPI.API.Filters;
using ExternalWebhookReceiverAPI.CrossCutting.DependencyInjection;
using ExternalWebhookReceiverAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore; // Add this using directive for 'UseSqlServer'
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true; // Força todas as URLs para minúsculo
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringSqlServer = builder.Configuration.GetConnectionString("DefaultConnectionSqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(stringSqlServer));

builder.Services.AddOptionsInjectionConfig(builder.Configuration);
builder.Services.AddDependencyInjectionConfig();
builder.Services.AddHttpContextAccessor();

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