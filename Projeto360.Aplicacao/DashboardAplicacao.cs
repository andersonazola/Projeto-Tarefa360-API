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

            //Busca tarefas ativas com as respectivas Sprints
            var tarefas = await _tarefaRepositorio.ObterTarefasComSprintPorProjeto(projetoId);

            int totalHoras = 0;
            int horasConcluidas = 0;
            int horasAbertas = 0;

            // Foreach percorrendo cada tarefa
            foreach (var tarefa in tarefas)
            {
                if (tarefa.Sprint != null && tarefa.Sprint.DataInicio != DateTime.MinValue && tarefa.Sprint.DataFim != DateTime.MinValue)
                {
                    int diasUteis = 0;

                    //Percorre dia a dia da Sprint
                    for (var data = tarefa.Sprint.DataInicio.Date; data <= tarefa.Sprint.DataFim.Date; data = data.AddDays(1))
                    {
                        //Verifica se o dia é útil (segunda a sexta-feira)
                        if (data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday)
                        {
                            diasUteis++;
                        }
                    }

                    // Cada dia útil equivale a 8 horas
                    int horasDaTarefa = diasUteis * 8;

                    if (tarefa.Concluida)
                    {
                        horasConcluidas += horasDaTarefa;
                    }
                    else
                    {
                        horasAbertas += horasDaTarefa;
                    }

                    totalHoras += horasDaTarefa;                    
                }
            }

            resumo.TotalHoras = totalHoras;
            resumo.HorasConcluidas = horasConcluidas;
            resumo.HorasAbertas = horasAbertas;

            // Busca dados de Histórias
            resumo.TotalHistorias    = await _historiaRepositorio.ContarTotalHistorias(projetoId);
            resumo.HistoriasFechadas = await _historiaRepositorio.ContarHistoriasFechadas(projetoId);
            resumo.HistoriasAbertas  = await _historiaRepositorio.ContarHistoriasAbertas(projetoId);           

            // Busca dados de Bugs
            resumo.TotalBugs    = await _tarefaRepositorio.ContarTotalBugs(projetoId);
            resumo.BugsFechados = await _tarefaRepositorio.ContarBugsFechados(projetoId);
            resumo.BugsAbertos  = await _tarefaRepositorio.ContarBugsAbertos(projetoId);
            
            return resumo;
        }
    }
}