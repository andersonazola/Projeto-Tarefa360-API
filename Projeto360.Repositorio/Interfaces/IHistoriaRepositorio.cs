using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;

namespace Projeto360.Repositorio.Interfaces
{
    public interface IHistoriaRepositorio
    {
        Task<int> Salvar(Historia historia);
        Task Atualizar(Historia historia);
        Task<Historia> Obter(int historiaId);
        Task Deletar(Historia historia);
        Task<IEnumerable<Historia>> Listar(bool ativo);
    }
}