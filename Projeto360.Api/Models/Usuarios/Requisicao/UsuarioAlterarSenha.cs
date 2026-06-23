namespace Projeto360.Api.Models.Requisicao;

public class UsuarioAlterarSenha
{
    public int Id { get; set; }
    public string Senha { get; set; }   
    public string SenhaAntiga {get; set;}
}