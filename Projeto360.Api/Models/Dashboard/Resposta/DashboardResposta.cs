namespace Projeto360.Api.Models.Dashboard.Resposta
{
    public class DashboardResposta
    {
        public int ProjetoId {get; set;}
        
        //Indicadores de Tarefas
        public int TotalTarefas {get; set;}
        public int TarefasConcluidas {get; set;}
        public int TarefasFechadas {get; set;}

        //Indicadores de Historias
        public int TotalHistorias {get; set;}
        public int HistoriasFechadas {get; set;}
        public int HistoriasAbertas {get; set;}

        //Indicadores de Bug
        public int TotalBugs {get; set;}
        public int BugsFechados {get; set;}
        public int BugsAbertos {get; set;}
    }
}