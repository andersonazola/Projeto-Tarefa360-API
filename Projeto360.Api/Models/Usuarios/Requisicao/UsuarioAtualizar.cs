using Microsoft.AspNetCore.SignalR;

namespace Projeto360.Api.Models.Requisicao;

public class UsuarioAtualizar
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}