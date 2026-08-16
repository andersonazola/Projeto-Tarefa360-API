using System.Runtime.CompilerServices;
using Projeto360.Dominio.Enumeradores;
using Projeto360.Entidades;

namespace Projeto360.Dominio.Entidades;

public class Tarefa
{
    public int ID { get; set; }
    public string Nome { get; set; }

    public Projeto Projeto { get; set; }
    public int ProjetoId { get; set; }

    public Historia Historia { get; set; }
    public int HistoriaId { get; set; }

    public Sprint Sprint { get; set; }
    public int SprintId { get; set; }

    public string Descricao { get; set; }
    public TiposTarefas TipoTarefas { get; set; }

    public Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }

    public bool Concluida { get; set; }


    public Tarefa()
    {
        Concluida = false;

    }
}