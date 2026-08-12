using DataAccess.Configuracores;
using Microsoft.EntityFrameworkCore;
using Projeto360.Dominio.Entidades;
using Projeto360.Repositorio.Configuracoes;

public class Projeto360Contexto : DbContext
{
    private readonly DbContextOptions _options;
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Projeto> Projetos { get; set; }
    
    // public Projeto360Contexto() { }
    public Projeto360Contexto(DbContextOptions options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
        modelBuilder.ApplyConfiguration(new ProjetoConfiguracoes());
        
    }

}