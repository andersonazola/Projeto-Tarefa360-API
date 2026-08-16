using Projeto360.Entidades;
namespace Projeto360.Dominio.Entidades;

public class Sprint 
{
    public int Id {get; set;}

    public string Nome { get; set; }

    public DateTime DataInicio {get; set;}

    public DateTime DataFim {get; set;}

    public List <Projeto> Projetos {get; set;}

    public Projeto Projeto {get; set;}
    
    public int ProjetoId {get; set;}

    public void Validar()
    {
       
        if (DataFim < DataInicio)
        {
            throw new ArgumentException ("Erro");
        }
    }

}