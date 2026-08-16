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

        builder.Property(sprint => sprint.ID).HasColumnName("Sprints").IsRequired(true);
        builder.Property(sprint => sprint.Nome).HasColumnName("Nome").IsRequired(true).HasMinimunLenght(3).HasMaxLength(100);
        builder.Property(sprint => sprint.ProjetoId).HasColumnName("ProjetoId").IsRequired(true);
        builder.Property(sprint => sprint.DataInicio).HasColumnName("Data Inicio").HasColumnType(datetime).IsRequired(true);
        builder.Property(sprint => sprint.DataFim).HasColumnName("Data Fim").HasColumnType(datetime).IsRequired(true);

        builder
        .HasOne(sprint => sprint.Projeto)
        .HasForeignKey(sprint = sprint.ProjetoId);
    }
}