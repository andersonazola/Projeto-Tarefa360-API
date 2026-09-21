using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;

namespace Projeto360.Aplicacao;

public interface IUsuarioAplicacao
{
    Task<int> Criar(Usuario usuarioDTOm, int usuarioLoginId);
    Task AlterarSenha(Usuario usuarioDTO, string senhaAntiga, int usuarioLoginId);
    Task Atualizar(Usuario usuarioDTO, int usuarioLoginId);
    Task Deletar(int usuarioId, int usuarioLoginId);
    Task Restaurar(int usuarioId, int usuarioLoginId);
    Task<IEnumerable<Usuario>> Listar(bool ativo, int usuarioLoginId);
    Task<Usuario> Obter(int usuarioId, int usuarioLoginId);
    Task<Usuario> ObterPorEmail(string email, int usuarioLoginId);
    Task<IEnumerable<Usuario>> Busca(string filtro, bool ativo = true);
}