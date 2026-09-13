using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;

namespace Projeto360.Repositorio.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<int> Salvar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task<Tarefa> Obter(int tarefaId);
        Task Deletar(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> Listar(bool? concluida);
        Task ConcluirTarefa (Tarefa tarefa);

        //Métodos para o Dashboard
        Task <int> ContarTotalTarefas(int projetoId);
        Task <int> ContarTarefasConcluidas(int projetoId);
        Task <int> ContarTarefasAbertas(int projetoId);
        Task<int> ContarTotalBugs(int projetoId);
        Task<int> ContarBugsFechados(int projetoId);
        Task<int> ContarBugsAbertos(int projetoId);
        Task<List<Tarefa>> ObterTarefasComSprintPorProjeto(int projetoId);
    }
} 