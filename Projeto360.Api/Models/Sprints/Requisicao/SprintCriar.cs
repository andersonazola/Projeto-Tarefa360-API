namespace Projeto360.Api.Models.Requisicao;

public class SprintCriar
{
    
    public string Nome {get; set;}

    public int ProjetoId {get; set;}

    public DateTime DataInicio {get; set;}

    public DateTime DataFim {get; set;}
}