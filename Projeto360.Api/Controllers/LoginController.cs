using Microsoft.AspNetCore.Mvc;
using Projeto360.Api.Models.Requisicao;

namespace Projeto360.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly Projeto360Contexto _contexto;

        public LoginController(Projeto360Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult> Login([FromBody] LoginRequisicao loginRequisicao)
        {
            try
            {
                var usuarioLogin = new LoginRequisicao
                {
                    Email = loginRequisicao.Email, 
                    Senha = loginRequisicao.Senha
                };

                var usuarioValidacao = _contexto.Usuarios.FirstOrDefault(usuario => usuario.Email == usuarioLogin.Email);

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

