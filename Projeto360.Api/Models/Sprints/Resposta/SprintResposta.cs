using Projeto360.Dominio.Entidades;

namespace Projeto360.Api.Models.Resposta;

public class SprintResposta
{
    public int Id {get; set;}

    public string Nome {get; set;}

    public int ProjetoId {get; set;}
    public string NomeProjeto {get; set;}

    public DateTime DataInicio {get; set;}

    public DateTime DataFim {get; set;}
}