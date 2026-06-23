using Microsoft.EntityFrameworkCore;
using Projeto360.Dominio.Entidades;
using Projeto360.Repositorio.Configuracoes;

public class Projeto360Contexto : DbContext
{
    private readonly DbContextOptions _options;
    public DbSet<Usuario> Usuarios { get; set; }  
    public Projeto360Contexto() { }
    public Projeto360Contexto(DbContextOptions options) : base(options)
    {
        _options = options;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_options == null)
            optionsBuilder.UseSqlite(@"Filename=./Projeto360.sqlite;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
    }


    

}