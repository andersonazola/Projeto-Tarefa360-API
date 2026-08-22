namespace Projeto360.Api.Models.Requisicao;

public class SprintCriar
{
    public string Nome {get; set;}

    public int ProjetoId {get; set;}

    public Datetime DataInicio {get; set;}

    public Datetime DataFim {get; set;}
}