using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;
using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Aplicacao;

public class UsuarioAplicacao : IUsuarioAplicacao
{
    readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }


    public async Task<int> Criar(Usuario usuario, int usuarioLoginId)
    {
        await ValidarPermissaoAdmin(usuarioLoginId);

        if (usuario == null)
            throw new Exception("Usuário não pode ser vazio");

        ValidarInformacoesUsuario(usuario);

        if (string.IsNullOrEmpty(usuario.Senha))
            throw new Exception("Senha não pode ser vázia");

        if (usuario.Senha.Length < 6)
            throw new Exception("A senha temporária deve ter no mínimo 6 caracteres.");



        return await _usuarioRepositorio.Salvar(usuario);
    }


    public async Task Atualizar(Usuario usuario, int usuarioLoginId)
    {
        await ValidarPermissaoAdmin(usuarioLoginId);

        var usuarioDominio = await _usuarioRepositorio.Obter(usuario.ID);

        if (usuarioDominio == null)
            throw new Exception("Usuario não encontrado");

        ValidarInformacoesUsuario(usuarioDominio);

        usuarioDominio.Nome = usuario.Nome;
        usuarioDominio.Email = usuario.Email;

        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task TrocarSenhaPrimeiroAcesso(int usuarioId, string novaSenha)
    {
        if (string.IsNullOrEmpty(novaSenha) || novaSenha.Length < 6)
            throw new Exception("A nova senha deve ter no mínimo 6 caracteres.");

        var usuarioDominio = await _usuarioRepositorio.ObterPorId(usuarioId);

        if (usuarioDominio == null)
            throw new Exception("Usuario não encontrado");

        usuarioDominio.TrocarSenhaPrimeiroAcesso(novaSenha);

        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }


    public async Task AlterarSenha(Usuario usuario, string senhaAntiga, int usuarioLoginId)
    {
        await ValidarPermissaoAdmin(usuarioLoginId);
        var usuarioDominio = await _usuarioRepositorio.Obter(usuario.ID);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado.");

        if (usuarioDominio.Senha != senhaAntiga)
            throw new Exception("Senha antiga inválida");

        usuarioDominio.Senha = usuario.Senha;

        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task<Usuario> Obter(int usuarioId, int usuarioLoginId)
    {
        await ValidarPermissaoAdmin(usuarioLoginId);

        var usuarioDominio = await _usuarioRepositorio.Obter(usuarioId);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado");

        return usuarioDominio;
    }


    public async Task<Usuario> ObterPorEmail(string email, int usuarioLoginId)
    {
        await ValidarPermissaoAdmin(usuarioLoginId);

        var usuarioDominio = await _usuarioRepositorio.ObterEmail(email);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado");

        return usuarioDominio;
    }

    public async Task Deletar(int usuarioId, int usuarioLoginId)
    {
        await ValidarPermissaoAdmin(usuarioLoginId);

        var usuarioDominio = await _usuarioRepositorio.Obter(usuarioId);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado");

        usuarioDominio.Deletar();
        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task Restaurar(int usuarioId, int usuarioLoginId)
    {
        await ValidarPermissaoAdmin(usuarioLoginId);

        var usuarioDominio = await _usuarioRepositorio.ObterPorId(usuarioId);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado");

        usuarioDominio.Restaurar();
        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task<IEnumerable<Usuario>> Listar(bool ativo, int usuarioId)
    {
        await ValidarPermissaoAdmin(usuarioId);

        return await _usuarioRepositorio.Listar(ativo);
    }

    public async Task<IEnumerable<Usuario>> Busca(string filtro, int usuarioId, bool ativo = true)
    {
        await ValidarPermissaoAdmin(usuarioId);
        return await _usuarioRepositorio.Busca(filtro, ativo);
    }


    public async Task<IEnumerable<Usuario>> ListarDropUsuarios(int usuarioLoginId)
    {
        var usuarioLogin = await _usuarioRepositorio.Obter(usuarioLoginId);
        if (usuarioLogin == null)
            throw new ArgumentException("Usuario não encontrado");

        return await _usuarioRepositorio.Listar(true);
    }

    #region  Util
    private static void ValidarInformacoesUsuario(Usuario usuario)
    {
        if (string.IsNullOrEmpty(usuario.Nome))
            throw new Exception("Nome não pode ser vázio");

        if (string.IsNullOrEmpty(usuario.Email))
            throw new Exception("E-mail não pode ser vazio");
    }


    private async Task ValidarPermissaoAdmin(int usuarioId)
    {
        var usuarioLogin = await _usuarioRepositorio.Obter(usuarioId);

        if (usuarioLogin == null)
            throw new ArgumentException("Usuario não encontrado");

        if (usuarioLogin.TipoUsuario != TiposUsuarios.Admin)
            throw new UnauthorizedAccessException("Acesso restrito a administradores");
    }


    #endregion
}