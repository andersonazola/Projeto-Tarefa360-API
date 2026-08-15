using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto360.Dominio.Entidades;

namespace Projeto360.Repositorio.Configuracoes;

public class SprintConfiguracoes : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        builder.ToTable("Sprints").HasKey (x =x.ID);

        builder.Property(sprint => Sprint.ID)
    }
}