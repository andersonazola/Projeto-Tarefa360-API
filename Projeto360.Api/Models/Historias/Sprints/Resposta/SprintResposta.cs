using Projeto360.Dominio.Entidades;

namespace Projeto360.Api.Models.Resposta;

public class SprintResposta
{
    public int Id {get; set;}

    public int Nome {get; set;}

    public int ProjetoId {get; set;}

    public Datetime DataInicio {get; set;}

    public Datetime DataFim {get; set;}
}