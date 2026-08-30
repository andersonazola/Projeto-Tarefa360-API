using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Api.Models.Tarefas.Resposta;

public class TarefaResposta
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public TiposTarefas TiposTarefas { get; set; }
    public bool Concluida { get; set; }
    public bool Ativa { get; set; }

    public int ProjetoId { get; set; }
    public string NomeProjeto { get; set; }

    public int HistoriaId { get; set; }
    public string NomeHistoria { get; set; }
    public int SprintId { get; set; }
    public string NomeSprint { get; set; }
    public int UsuarioId { get; set; }
    public string NomeUsuario { get; set; }


}