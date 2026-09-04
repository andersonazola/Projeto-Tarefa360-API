using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;

namespace Projeto360.Aplicacao.Interfaces
{
    public interface IDashboardAplicacao
    {
        Task<ResumoDashboard> ObterDadosDashboard(int projetoId);
    }
}