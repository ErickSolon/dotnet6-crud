using EstudoRepositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstudoRepositories.Data.Map;
public class CondutorMap : IEntityTypeConfiguration<Condutor>
{
    public void Configure(EntityTypeBuilder<Condutor> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(255);
        builder.Property(x => x.CPF).IsRequired().HasMaxLength(255);
    }
}
