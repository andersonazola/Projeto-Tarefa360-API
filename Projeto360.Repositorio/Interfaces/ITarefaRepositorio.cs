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
    }
} 