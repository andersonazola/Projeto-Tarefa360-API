using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;

namespace Projeto360.Aplicacao;

public interface IUsuarioAplicacao
{
    Task<int> Criar(Usuario usuarioDTO);
    Task Atualizar(Usuario usuarioDTO);
    Task AlterarSenha(Usuario usuarioDTO, string senhaAntiga);
    Task TrocarSenhaPrimeiroAcesso(int usuarioId, string novaSenha);   
    Task<Usuario> Obter(int usuarioId);
    Task<Usuario> ObterPorEmail(string email);
    Task Deletar(int usuarioId);
    Task Restaurar(int usuarioId);
    Task<IEnumerable<Usuario>> Listar(bool ativo);   
    
}