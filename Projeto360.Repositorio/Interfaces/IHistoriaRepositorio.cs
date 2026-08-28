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
        int ContarTotalHistorias(int projetoId); // Método para o Dashboard
        int ContarHistoriasFechadas(int projetoId); // Método para o Dashboard
        int ContarHistoriasAbertas(int projetoId); // Método para o Dashboard
    }
}