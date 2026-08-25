
namespace Projeto360.Api.Models.Resposta;

public class UsuarioResposta
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public bool PrecisaTrocarSenha {get; set;} //Campo para o frontend saber se o usuário está em primeiro acesso
}