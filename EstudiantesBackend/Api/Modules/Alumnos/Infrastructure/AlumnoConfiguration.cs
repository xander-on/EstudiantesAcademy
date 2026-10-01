using Api.Modules.Alumnos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modules.Alumnos.Infrastructure;

public class AlumnosConfiguration : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> entity)
    {
        entity.ToTable("Alumnos");
        entity.HasKey(x => x.Id);

        entity.Property(x => x.Dni).HasMaxLength(15).IsRequired();
        entity.Property(x => x.Name).HasMaxLength(100).IsRequired();
        entity.Property(x => x.LastName).HasMaxLength(100).IsRequired();
        }
}