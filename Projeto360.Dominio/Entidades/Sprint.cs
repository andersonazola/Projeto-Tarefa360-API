using System.ComponentModel.DataAnnotations;

namespace Projeto360.Dominio.Entidades;

public class Sprint 
{
    public int ID {get; set;}

    public string Nome { get; set; }

    public DateTime DataInicio {get; set;}

    public DateTime DataFim {get; set;}


//REFAZER O DOMINIO COM A SARA MERGEANDO A BRANCH DELA POR CONTA QUE O PROJETOS É PUXADO DE LA
}