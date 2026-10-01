namespace Api.Modules.Shared.Infrastructure.Persistence;

using Api.Modules.Alumnos.Domain;
using Api.Modules.Carreras.Domain;
using Api.Modules.Materias.Domain;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);    


    public DbSet<Materia> Materias => Set<Materia>();
    public DbSet<Alumno> Alumnos => Set<Alumno>();
    public DbSet<Carrera> Carreras => Set<Carrera>();
    public DbSet<CarreraMateria> CarrerasMaterias => Set<CarreraMateria>();
}