using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;
namespace Projeto360.Aplicacao;

public interface ITarefaAplicacao
{
    Task<int> Criar(Tarefa tarefa);
    Task Atualizar(Tarefa tarefa);
    Task Deletar(int tarefaId);
    Task<Tarefa> Obter(int tarefaId);
    Task<IEnumerable<Tarefa>> ListarTodasTarefas();
    Task<IEnumerable<Tarefa>> Listar(bool concluida);
    Task ConcluirTarefa(int tarefaId);
}