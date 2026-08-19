using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Api.Models.Requisicao;

public class TarefaAtualizar
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public TiposTarefas TiposTarefas { get; set; }
    public bool Concluida { get; set; }

    public int ProjetoId { get; set; }
    public int HistoriaId { get; set; }
    public int SprintId { get; set; }
    public int UsuarioId { get; set; }
}