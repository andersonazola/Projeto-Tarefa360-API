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
        [Route("Login")]

        public async Task<ActionResult> Login([FromBody] LoginRequisicao loginRequisicao)
        {
            try
            {
                var usuarioLogin = _contexto.Usuarios.Where
                    (usuario => usuario.Email == loginRequisicao.Email && usuario.Senha == loginRequisicao.Senha);

                return Ok();
            }
            catch(Exception excecao)
            {
                return BadRequest(excecao.Message); 
            }
            
        }
    }
}