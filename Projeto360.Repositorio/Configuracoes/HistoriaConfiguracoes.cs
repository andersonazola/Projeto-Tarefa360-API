using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;

namespace Projeto360.Repositorio.Configuracoes;

public class HistoriaConfiguracoes : IEntityTypeConfiguration<Historia>
{
    public void Configure(EntityTypeBuilder<Historia> builder)
    {
        builder.ToTable("Historias").HasKey(historia => historia.Id);

        builder.Property(historia => historia.Id).HasColumnName("HistoriaId").IsRequired(true);
        builder.Property(historia => historia.Nome).HasColumnName("Nome").IsRequired(true).HasMaxLength(100);        
        builder.Property(historia => historia.ProjetoId).HasColumnName("ProjetoId").IsRequired(true);
        builder.Property(historia => historia.Descricao).HasColumnName("Descricao").IsRequired(false).HasMaxLength(500);
        builder.Property(historia => historia.Ativo).HasColumnName("Ativo").IsRequired(true);

        builder
        .HasOne(historia => historia.Projeto)
        .WithMany(projeto => projeto.Historias)
        .HasForeignKey(historia => historia.ProjetoId);

    }
}