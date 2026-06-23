using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto360.Dominio.Entidades;

namespace Projeto360.Repositorio.Configuracoes;

public class UsuarioConfiguracoes : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario").HasKey(x => x.ID);

        builder.Property(nameof(Usuario.ID)).HasColumnName("UsuarioId");
        builder.Property(nameof(Usuario.Nome)).HasColumnName("Nome").IsRequired(true).HasMaxLength(100);
        builder.Property(nameof(Usuario.Email)).HasColumnName("Email").IsRequired(true);
        builder.Property(nameof(Usuario.Senha)).HasColumnName("Senha").IsRequired(true);
        builder.Property(nameof(Usuario.Ativo)).HasColumnName("Ativo").IsRequired(true);
    }


}