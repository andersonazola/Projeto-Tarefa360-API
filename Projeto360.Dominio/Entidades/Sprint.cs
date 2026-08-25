using Projeto360.Entidades;
namespace Projeto360.Dominio.Entidades;

public class Sprint 
{
    public int Id {get; set;}

    public string Nome { get; set; }

    public DateTime DataInicio {get; set;}

    public DateTime DataFim {get; set;}

    public bool Ativo { get; set; } 

    public List <Projeto> Projetos {get; set;}

    public Projeto Projeto {get; set;}
    
    public int ProjetoId {get; set;}

    public void Validar()
    {
        ValidarNome(Nome);
       
        if (DataFim < DataInicio)
        {
            throw new ArgumentException ("Erro");
        }
    }

    public void ValidarNome(string nome)
    {
        if (string.IsNullOrEmpty(nome))
        {
            throw new ArgumentException ("Nome é obrigatório");

        }

        if (Nome.Length < 3 || Nome.Length > 100)
        {
                throw new ArgumentException ("Nome deve ter entre 3 e 100 caracteres");
        }
    }

    public Sprint()
    {
        Ativo = true;
    }

}