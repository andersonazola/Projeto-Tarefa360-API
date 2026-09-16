using System;
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
            var usuario = new Usuario
            {
                Email = usuarioLogin.Email,
                Senha = usuarioLogin.Senha
            };

            var usuarioValidacao = _usuarioRepositorio.ObterEmail(usuario.Email);

            return await usuarioValidacao;
        }
    }
}