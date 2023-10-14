using EstudoRepositories.Data;
using EstudoRepositories.Repositories;
using EstudoRepositories.Repositories.Interfaces;
using EstudoRepositories.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<ProjetoContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// Services
builder.Services.AddScoped<IMultaService, MultaService>();

// Repositories
builder.Services.AddScoped<ICondutorRepository, CondutorRepository>();

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
