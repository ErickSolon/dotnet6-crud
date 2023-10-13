using EstudoRepositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstudoRepositories.Data.Map;
public class VeiculoMap : IEntityTypeConfiguration<Veiculos>
{
    public void Configure(EntityTypeBuilder<Veiculos> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Placa).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Marca).IsRequired().HasMaxLength(255);
    }
}
