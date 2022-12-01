using Microsoft.AspNetCore.Mvc;
using RedisSample.Business.Services;
using RedisSample.StartupConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRedisConnection(builder.Configuration);
builder.Services.AddSingleton<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/CategoryGetAll", ([FromServices] ICategoryService service) =>
{
    return service.GetAll();
});

app.Run();