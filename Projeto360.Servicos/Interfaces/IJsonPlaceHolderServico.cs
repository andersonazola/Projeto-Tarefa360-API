using Projeto360.Dominio.Entidades;

namespace Projeto360.Servicos.Interfaces;

public interface IJsonPlaceHolderServico
{
    Task<List<Tarefa>> ListarTarefas();
}