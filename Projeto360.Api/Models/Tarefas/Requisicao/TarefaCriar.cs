using Projeto360.Dominio.Entidades;
using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Api.Models.Requisicao;

public class TarefaCriar
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public TiposTarefas TiposTarefas { get; set; }
    public bool Concluida { get; set; }
    public bool Ativa { get; set; }

    public int ProjetoId { get; set; }
    public int HistoriaId { get; set; }
    public int SprintId { get; set; }
    public int UsuarioId { get; set; }


    public TarefaCriar()
    {
        Ativa = true;
        Concluida = false;
    }
}