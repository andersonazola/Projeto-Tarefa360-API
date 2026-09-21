using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;
using Projeto360.Repositorio;
using Tarefa360.Aplicacao.Interfaces;

namespace Projeto360.Aplicacao
{
    public class LoginAplicacao : ILoginAplicacao
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginAplicacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Usuario> Login(Usuario usuarioLogin)
        {
            var usuario = await _usuarioRepositorio.ObterEmail(usuarioLogin.Email);

            if(usuario == null)
            {
                throw new ArgumentException("Usuario não encontrado");
            }

            if(usuario.Senha != usuarioLogin.Senha)
            {
                throw new UnauthorizedAccessException("Senha incorreta");
            }

            return usuario;
        }
    }
}