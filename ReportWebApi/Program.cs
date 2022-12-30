using ReportWebApi.Models;
using ReportWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ReportDatabaseSettings>(
    builder.Configuration.GetSection("ReportDatabase"));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ReportService>();
builder.Services.AddSingleton<IMessageProducer, RabbitMQProducer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// This middleware serves generated Swagger document as a JSON endpoint
app.UseSwagger();

// This middleware serves the Swagger documentation UI
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
});
app.UseAuthorization();

app.MapControllers();

app.Run();
