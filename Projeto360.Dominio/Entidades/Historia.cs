using Projeto360.Dominio.Entidades;

namespace Projeto360.Entidades;

public class Historia
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Projeto Projeto { get; set; }
    public int ProjetoId { get; set; }
    public string Descricao { get; set; }
    public bool Ativo { get; set; }

    public Historia()
    {
        Ativo = true;
    }
}