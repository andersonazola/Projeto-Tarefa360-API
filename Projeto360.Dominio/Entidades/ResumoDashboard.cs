namespace Projeto360.Dominio.Entidades
{
    public class ResumoDashboard
    {
        public int ProjetoId {get; set;}
        public int TotalHoras {get; set;}
        public int HorasEntregues {get; set;}
        public int HorasRestantes {get; set;}
        public int TotalHistorias {get; set;}
        public int HistoriasFechadas {get; set;}
        public int HistoriasAbertas {get; set;}
        public int TotalBugs {get; set;}
        public int BugsFechados {get; set;}
        public int BugsAbertos {get; set;}
    }
}