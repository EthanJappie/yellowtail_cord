using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Yellowtail.Cord.Application;
using Yellowtail.Cord.Infrastructure;
using Yellowtail.Cord.Infrastructure.Persistence;
using Yellowtail.Cord.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Suppress Server header
builder.WebHost.ConfigureKestrel(o => o.AddServerHeader = false);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<Yellowtail.Cord.Filters.SwaggerHeaderFilter>();
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.Window = TimeSpan.FromMinutes(1);
        opt.PermitLimit = 100;
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 0;
    });
});

var app = builder.Build();

// Initialise SQLite Database
await app.Services.InitializeDatabaseAsync();

app.UseMiddleware<SecurityHeadersMiddleware>();
app.UseMiddleware<HeaderContextMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => c.RouteTemplate = "openapi/{documentName}.json");
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "Yellowtail.Cord API v1"));
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseRateLimiter();

app.MapControllers().RequireRateLimiting("fixed");

await app.RunAsync();
