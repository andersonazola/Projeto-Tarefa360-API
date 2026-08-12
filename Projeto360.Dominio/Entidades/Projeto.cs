namespace Projeto360.Dominio.Entidades

{
    public class Projeto
    {
        public int Id {get; set;}
        public string Nome {get; set;}        
        public string Descricao {get; set;}
        public bool Ativo {get; set;}

        public Projeto()
        {
            Ativo = true; //Todo projeto novo começa ativo por padrão
        }

        public void Deletar()
        {
            Ativo = false;
        }

        public void Restaurar()
        {
            Ativo = true;
        }
    }
}