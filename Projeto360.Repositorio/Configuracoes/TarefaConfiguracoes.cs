using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;
using Projeto360.Repositorio;

namespace Projeto360.Repositorio.Configuracoes;

public class TarefaConfiguracoes : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefas").HasKey(tarefa => tarefa.ID);

        builder.Property(tarefa => tarefa.ID).HasColumnName("TarefaId").IsRequired(true);
        builder.Property(tarefa => tarefa.Nome).HasColumnName("Nome").IsRequired(true).HasMaxLength(100);
        builder.Property(tarefa => tarefa.ProjetoId).HasColumnName("ProjetoId").IsRequired(true);
        builder.Property(tarefa => tarefa.HistoriaId).HasColumnName("HistoriaId").IsRequired(true);
        builder.Property(tarefa => tarefa.SprintId).HasColumnName("SprintId").IsRequired(true);
        builder.Property(tarefa => tarefa.TipoTarefas).HasColumnName("TipoTarefas").IsRequired(true);
        builder.Property(tarefa => tarefa.UsuarioId).HasColumnName("UsuarioId").IsRequired(true);
        builder.Property(tarefa => tarefa.Descricao).HasColumnName("Descricao").IsRequired(false);
        builder.Property(tarefa => tarefa.Concluida).HasColumnName("Concluida").IsRequired(true);


        builder
        .HasOne(tarefa => tarefa.Sprint)
        .WithMany()
        .HasForeignKey(tarefa => tarefa.SprintId)
        .IsRequired(true);

        builder
        .HasOne(tarefa => tarefa.Historia)
        .WithMany()
        .HasForeignKey(tarefa => tarefa.HistoriaId)
        .IsRequired(true)
        .OnDelete(DeleteBehavior.NoAction);

        builder
        .HasOne(tarefa => tarefa.Projeto)
        .WithMany()
        .HasForeignKey(tarefa => tarefa.ProjetoId)
        .IsRequired(true)
        .OnDelete(DeleteBehavior.NoAction);

        builder
        .HasOne(tarefa => tarefa.Usuario)
        .WithMany()
        .HasForeignKey(tarefa => tarefa.UsuarioId)
        .IsRequired(true);




    }
}