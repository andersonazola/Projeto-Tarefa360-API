using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;

namespace Projeto360.Repositorio.Configuracoes;

public class SprintConfiguracoes : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        builder.ToTable("Sprints").HasKey (sprint => sprint.Id);

        builder.Property(sprint => sprint.Id).HasColumnName("SprintId").IsRequired(true);
        builder.Property(sprint => sprint.Nome).HasColumnName("Nome").IsRequired(true).HasMaxLength(100);
        builder.Property(sprint => sprint.ProjetoId).HasColumnName("ProjetoId").IsRequired(true);
        builder.Property(sprint => sprint.DataInicio).HasColumnName("DataInicio").IsRequired(true);
        builder.Property(sprint => sprint.DataFim).HasColumnName("DataFim").IsRequired(true);

        builder.Property(sprint => sprint.HorasSprint)
        .HasColumnName("HorasSprint")
            .HasColumnName("HorasSprint")
            .HasColumnType("int")
            .IsRequired(true);

        builder
        .HasOne(sprint => sprint.Projeto)
        .WithMany()
        .HasForeignKey(sprint => sprint.ProjetoId);
    }
}