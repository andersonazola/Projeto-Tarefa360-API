using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto360.Dominio.Entidades;

namespace DataAccess.Configuracores
{
    public class ProjetoConfiguracoes : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projeto").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ProjetoId").IsRequired(true);
            builder.Property(x => x.Nome).HasColumnName("Nome").IsRequired(true);
            builder.Property(x => x.Descricao).HasColumnName("Descricao").IsRequired(false);
            builder.Property(x => x.Ativo).HasColumnName("Ativo").IsRequired(true);
        }
    }
}