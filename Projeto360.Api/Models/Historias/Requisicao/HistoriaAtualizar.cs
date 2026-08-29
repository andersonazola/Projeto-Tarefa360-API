using Projeto360.Dominio.Entidades;

namespace Projeto360.Api.Models.Requisicao;

public class HistoriaAtualizar
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int ProjetoId { get; set; }
    public string Descricao { get; set; }
}