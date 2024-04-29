using Interview.TaskScheduler.API.Extensions;
using Interview.TaskScheduler.API.Features.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.AddConfigurations();
builder.AddRabbitMQProducer();
builder.AddRabbitMQ();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x
		 .AllowAnyOrigin()
		 .AllowAnyMethod()
		 .AllowAnyHeader());
app.MapHub<JobsHub>("/jobs");
app.UseAuthorization();

app.MapControllers();

app.Run();
