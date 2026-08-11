using Projeto360.Dominio.Entidades;

namespace Projeto360.Repositorio.Interfaces
{
    public interface IProjetoRepositorio
    {
        Task<int> Salvar(Projeto projeto);
        Task Atualizar(Projeto projeto);
        Task <Projeto> Obter (int projetoId);
        Task <IEnumerable<Projeto>> Listar(bool ativo =true);
    }
}