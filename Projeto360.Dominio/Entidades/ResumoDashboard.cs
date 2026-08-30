namespace Projeto360.Dominio.Entidades
{
    public class ResumoDashboard
    {
        public int ProjetoId {get; set;}

        public int TotalTarefas {get; set;}
        public int TarefasConcluidas {get; set;}
        public int TarefasAbertas {get; set;}

        public int TotalHistorias {get; set;}
        public int HistoriasFechadas {get; set;}
        public int HistoriasAbertas {get; set;}

        public int TotalBugs {get; set;}
        public int BugsFechados {get; set;}
        public int BugsAbertos {get; set;}
    }
}