using Microsoft.AspNetCore.SignalR;
using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Api.Models.Requisicao;

public class UsuarioAtualizar
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public TiposUsuarios TipoUsuario { get; set; }
}