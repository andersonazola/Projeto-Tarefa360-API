using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;

namespace Projeto360.Repositorio.Interfaces
{
    public interface ISprintRepositorio
    {
        Task<int> Salvar (Sprint sprint);

        Task Atualizar (Sprint sprint);

        Task <Sprint> Obter (int sprintId);

        Task Deletar (Sprint sprint);

        Task <IEnumerable<Sprint>> Listar (bool ativo);
    }
}