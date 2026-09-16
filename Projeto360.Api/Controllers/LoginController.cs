using Microsoft.AspNetCore.Mvc;
using Projeto360.Api.Models.Requisicao;
using Projeto360.Dominio.Entidades;
using Tarefa360.Aplicacao.Interfaces;

namespace Projeto360.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly ILoginAplicacao _loginAplicacao;

        public LoginController(ILoginAplicacao loginAplicacao)
        {
            _loginAplicacao = loginAplicacao;
        }

        [HttpPost("")]
        public async Task<ActionResult> Login([FromBody] LoginRequisicao loginRequisicao)
        {
            try
            {
                var usuarioLogin = new Usuario
                {
                    Email = loginRequisicao.Email, 
                    Senha = loginRequisicao.Senha
                };

                var usuarioValidacao = await _loginAplicacao.Login(usuarioLogin);

                if (usuarioValidacao == null) 
                { 
                    return NotFound();
                }

                if (usuarioValidacao.Senha != usuarioLogin.Senha) 
                { 
                    return Unauthorized();
                }

                var usuarioResposta = new LoginResposta 
                { 
                    Nome = usuarioValidacao.Nome, 
                    TipoUsuario = (int)usuarioValidacao.TipoUsuario 
                }; 
                
                return Ok(usuarioResposta);
            }
            catch(Exception excecao)
            {
                return BadRequest(excecao.Message); 
            }
            
        }
    }
}

