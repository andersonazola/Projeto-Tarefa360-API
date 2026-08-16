using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;

namespace Projeto360.Aplicacao;

public class UsuarioAplicacao : IUsuarioAplicacao
{
    readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }


    public async Task<int> Criar(Usuario usuario)
    {
        if (usuario == null)
            throw new Exception("Usuário não pode ser vazio");

        ValidarInformacoesUsuario(usuario);

        if (string.IsNullOrEmpty(usuario.Senha))
            throw new Exception("Senha não pode ser vázia");

        return await _usuarioRepositorio.Salvar(usuario);
    }


    public async Task Atualizar(Usuario usuario)
    {
        var usuarioDominio = await _usuarioRepositorio.Obter(usuario.ID);

        if (usuarioDominio == null)
            throw new Exception("Usuario não encontrado");

        ValidarInformacoesUsuario(usuarioDominio);

        usuarioDominio.Nome = usuario.Nome;
        usuarioDominio.Email = usuario.Email;

        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }


    public async Task AlterarSenha(Usuario usuario, string senhaAntiga)
    {
        var usuarioDominio = await _usuarioRepositorio.Obter(usuario.ID);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado.");

        if (usuarioDominio.Senha != senhaAntiga)
            throw new Exception("Senha antiga inválida");

        usuarioDominio.Senha = usuario.Senha;

        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task<Usuario> Obter(int usuarioId)
    {
        var usuarioDominio = await _usuarioRepositorio.Obter(usuarioId);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado");

        return usuarioDominio;
    }


    public async Task<Usuario> ObterPorEmail(string email)
    {
        var usuarioDominio = await _usuarioRepositorio.ObterEmail(email);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado");

        return usuarioDominio;
    }

    public async Task Deletar(int usuarioId)
    {
        var usuarioDominio = await _usuarioRepositorio.Obter(usuarioId);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado");

        usuarioDominio.Deletar();
        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task Restaurar(int usuarioId)
    {
        var usuarioDominio = await _usuarioRepositorio.ObterPorId(usuarioId);

        if (usuarioDominio == null)
            throw new Exception("Usuário não encontrado");

        usuarioDominio.Restaurar();
        await _usuarioRepositorio.Atualizar(usuarioDominio);
    }

    public async Task<IEnumerable<Usuario>> Listar(bool ativo)
    {
        return await _usuarioRepositorio.Listar(ativo);
    }


    #region  Util
    private static void ValidarInformacoesUsuario(Usuario usuario)
    {
        if (string.IsNullOrEmpty(usuario.Nome))
            throw new Exception("Nome não pode ser vázio");

        if (string.IsNullOrEmpty(usuario.Email))
            throw new Exception("E-mail não pode ser vazio");
    }

    #endregion
}