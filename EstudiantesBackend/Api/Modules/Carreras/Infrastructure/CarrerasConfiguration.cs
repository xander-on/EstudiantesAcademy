using Api.Modules.Carreras.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modules.Carreras.Infrastructure;

public class CarrerasConfiguration : IEntityTypeConfiguration<Carrera>
{
    public void Configure(EntityTypeBuilder<Carrera> entity)
    {
        entity.ToTable("Carreras");
        entity.HasKey(x => x.Id);

        entity.Property(x => x.Code).HasMaxLength(20).IsRequired();
        entity.Property(x => x.Name).HasMaxLength(100).IsRequired();
        entity.Property(x => x.Description).HasMaxLength(1000);

        entity.HasIndex(x => x.Code)
            .IsUnique()
            .HasFilter("[Deleted] = 0");

        entity.HasMany(x => x.Materias)
            .WithOne(c => c.Carrera)
            .HasForeignKey(x => x.CarreraId);

    }
}