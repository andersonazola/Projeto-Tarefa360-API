namespace Projeto360.Api.Models.Requisicao;

public class ProjetoCriar
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Ativo { get; set; }

    public ProjetoCriar()
    {
        Ativo = true;
    }
}