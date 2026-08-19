namespace Projeto360.Dominio.Entidades;

public class Usuario
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }
    public TiposUsuario TipoUsuario { get; set; }
    public bool PrecisaTrocarSenha {get; set;}
    public bool Ativo {get; set;}


    public Usuario()
    {
        Ativo = true;
        PrecisaTrocarSenha = true; //Todo novo usuário cadastrado nasce precisando trocar senha
    }

    public void Deletar()
    {
        Ativo = false;
    }

    public void Restaurar()
    {
        Ativo = true;
    }

    public void PrecisaTrocarSenhaPrimeiroAcesso(string novaSenha)
    {
        Senha = novaSenha;
        PrecisaTrocarSenha = false; //Desmarca a flag no primeiro acesso concluído
    }

}