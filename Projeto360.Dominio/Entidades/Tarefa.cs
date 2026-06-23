namespace Projeto360.Dominio.Entidades;

public class Tarefa
{
    public int ID { get; set; }
    public string Nome {get; set;}
    public bool Completa {get;set;}


    public Tarefa()
    {
        Completa = false;
    }
}