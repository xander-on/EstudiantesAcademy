using Api.Materias;
using Application.Materias.Contracts;
using Application.Materias.Features;
using Infrastructure.Materias.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddMediatR(
    cfg => cfg.RegisterServicesFromAssemblyContaining<CreateMateriaCommand>()
);


builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapMateriasEndpoints();

app.UseHttpsRedirection();
app.Run();

