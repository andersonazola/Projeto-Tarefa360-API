namespace Projeto360.Api.Models.Dashboard.Resposta
{
    public class DashboardResposta
    {
        public int ProjetoId {get; set;}
        
        //Indicadores de Horas
        public int TotalHoras {get; set;}
        public int HorasEntregues {get; set;}
        public int HorasRestantes {get; set;}

        //Indicadores de Histórias
        public int TotalHistorias {get; set;}
        public int HistoriasFechadas {get; set;}
        public int HitoriasAbertas {get; set;}

        //Indicadores de Bugs
        public int TotalBugs {get; set;}
        public int BugsFechados {get; set;}
        public int BugsAbertos {get; set;}
    }
}