using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KRPizzeriaAPI.Controllers;
using KRPizzeriaAPI.Data;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddSqlServer<KrproyectoPizzeriaContext>(builder.Configuration.GetConnectionString("PizzeriaConection"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapKRPizzeriaEndpoints();

app.Run();
