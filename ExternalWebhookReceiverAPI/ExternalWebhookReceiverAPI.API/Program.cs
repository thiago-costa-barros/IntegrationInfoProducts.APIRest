using CommonSolution.Filters;
using CommonSolution.Middleware;
using CommonSolution.CrossCutting.PostgresSQL;
using ExternalWebhookReceiverAPI.Application.Services;
using ExternalWebhookReceiverAPI.CrossCutting.DependencyInjection;
using FluentValidation;


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

// Configs
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddOptionsInjectionConfig(builder.Configuration);
builder.Services.AddDependencyInjectionConfig();
builder.Services.AddDatabaseConfig(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddValidatorsFromAssemblyContaining<AssemblyReferenceApplication>();

var app = builder.Build();

app.UseMiddleware<ApiLoggingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable ping endpoint for health checks
app.MapGet("/health", () => Results.Ok(new { status = "OK", time = DateTime.UtcNow }));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();