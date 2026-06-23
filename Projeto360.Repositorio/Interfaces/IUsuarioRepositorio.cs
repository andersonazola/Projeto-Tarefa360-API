
using System.Reflection.Metadata;
using Projeto360.Dominio.Entidades;

public interface IUsuarioRepositorio
{
    Task <int> Salvar(Usuario usuario);
    Task Atualizar(Usuario usuario);
    Task<Usuario> Obter(int usuarioId);
    Task<Usuario> ObterPorId(int usuarioId);
    Task<Usuario> ObterEmail(string email);
    Task<IEnumerable<Usuario>> Listar(bool ativo);

}