using System;
using System.Threading.Tasks;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio.Entidades;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Aplicacao
{
    public class DashboardAplicacao : IDashboardAplicacao
    {
        private readonly IHistoriaRepositorio _historiaRepositorio;
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly IProjetoRepositorio _projetoRepositorio;

        public DashboardAplicacao(IHistoriaRepositorio historiaRepositorio, ITarefaRepositorio tarefaRepositorio, IProjetoRepositorio projetoRepositorio)
        {
            _historiaRepositorio = historiaRepositorio;
            _tarefaRepositorio = tarefaRepositorio;
            _projetoRepositorio = projetoRepositorio;
        }

        public async Task <ResumoDashboard> ObterDadosDashboard(int projetoId)
        {
            //Valida se o projeto existe
            var projeto = await _projetoRepositorio.Obter(projetoId);
            if (projeto == null)
            {
                throw new Exception("Projeto não encontrado.");
            }

            var resumo = new ResumoDashboard();
            resumo.ProjetoId = projetoId;

            // Busca dados de Histórias
            resumo.TotalHistorias    = await _historiaRepositorio.ContarTotalHistorias(projetoId);
            resumo.HistoriasFechadas = await _historiaRepositorio.ContarHistoriasFechadas(projetoId);
            resumo.HistoriasAbertas  = await _historiaRepositorio.ContarHistoriasAbertas(projetoId);

            // Busca dados de Tarefas
            resumo.TotalTarefas      = await _tarefaRepositorio.ContarTotalTarefas(projetoId);
            resumo.TarefasConcluidas = await _tarefaRepositorio.ContarTarefasConcluidas(projetoId);
            resumo.TarefasAbertas    = await _tarefaRepositorio.ContarTarefasAbertas(projetoId);

            // Busca dados de Bugs
            resumo.TotalBugs    = await _tarefaRepositorio.ContarTotalBugs(projetoId);
            resumo.BugsFechados = await _tarefaRepositorio.ContarBugsFechados(projetoId);
            resumo.BugsAbertos  = await _tarefaRepositorio.ContarBugsAbertos(projetoId);
            
            return resumo;
        }
    }
}