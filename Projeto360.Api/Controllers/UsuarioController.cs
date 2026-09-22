using Microsoft.AspNetCore.Mvc;
using Projeto360.Dominio.Entidades;
using Projeto360.Api.Models.Requisicao;
using Projeto360.Api.Models.Resposta;
using Projeto360.Aplicacao;

using Projeto360.Dominio.Enumeradores;



namespace Projeto360.Api;

[ApiController]
[Route("[controller]")]

public class UsuarioController : ControllerBase
{

    private readonly IUsuarioAplicacao _usuarioAplicacao;

    public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
    {
        _usuarioAplicacao = usuarioAplicacao;
    }


    [HttpGet]
    [Route("obter/{usuarioId}")]
    public async Task<ActionResult> Obter([FromRoute] int usuarioId, [FromHeader(Name = "Usuario-Id")] int usuarioLoginId)
    {
        try
        {
            var usuarioDominio = await _usuarioAplicacao.Obter(usuarioId, usuarioLoginId);
            var usuario = new UsuarioResposta()
            {
                Id = usuarioDominio.ID,
                Nome = usuarioDominio.Nome,
                Email = usuarioDominio.Email,
                TipoUsuario = usuarioDominio.TipoUsuario
            };
            return Ok(usuario);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("Criar")]
    public async Task<ActionResult> Criar([FromBody] UsuarioCriar usuario, [FromHeader(Name = "Usuario-Id")] int usuarioLoginId)
    {
        try
        {
            var usuarioDominio = new Usuario()
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                TipoUsuario = usuario.TipoUsuario
            };
            var usuarioID = await _usuarioAplicacao.Criar(usuarioDominio, usuarioLoginId);
            return Ok(usuarioID);

        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [HttpPut]
    [Route("Atualizar")]

    public async Task<ActionResult> Atualizar([FromBody] UsuarioAtualizar usuario, [FromHeader(Name = "Usuario-Id")] int usuarioLoginId)
    {
        try
        {
            var usuarioDominio = new Usuario()
            {
                ID = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuario = usuario.TipoUsuario
            };
            await _usuarioAplicacao.Atualizar(usuarioDominio, usuarioLoginId);

            return Ok();
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("AlterarSenha")]
    public async Task<ActionResult> AlterarSenha([FromBody] UsuarioAlterarSenha usuario, [FromHeader(Name = "Usuario-Id")] int usuarioLoginId)
    {
        try
        {
            var usuarioDominio = new Usuario()
            {
                ID = usuario.Id,
                Senha = usuario.Senha
            };
            await _usuarioAplicacao.AlterarSenha(usuarioDominio, usuario.SenhaAntiga, usuarioLoginId);

            return Ok();
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("Deletar/{usuarioId}")]
    public async Task<ActionResult> Deletar([FromRoute] int usuarioId, [FromHeader(Name = "Usuario-Id")] int usuarioLoginId)
    {
        try
        {
            await _usuarioAplicacao.Deletar(usuarioId, usuarioLoginId);

            return Ok();
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Restaurar/{usuarioId}")]
    public async Task<ActionResult> Restaurar([FromRoute] int usuarioId, [FromHeader(Name = "Usuario-Id")] int usuarioLoginId)
    {
        try
        {
            await _usuarioAplicacao.Restaurar(usuarioId, usuarioLoginId);

            return Ok();
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Listar")]
    public async Task<ActionResult> Listar([FromQuery] bool ativos, [FromHeader(Name = "Usuario-Id")] int usuarioLoginId)
    {
        try
        {
            var usuarioDominio = await _usuarioAplicacao.Listar(ativos, usuarioLoginId);
            var usuarios = usuarioDominio.Select(usuario => new UsuarioResposta()
            {
                Id = usuario.ID,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuario = usuario.TipoUsuario
            }).ToList();

            return Ok(usuarios);

        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ListarTiposUsuario")]
    public ActionResult ListarTipoUsuario()
    {
        try
        {
            var tipoUsuarios = (string[])Enum.GetNames(typeof(TiposUsuarios));
            var valorUsuarios = (int[])Enum.GetValues(typeof(TiposUsuarios));

            var resposta = new List<object>();

            for (var cont = 0; cont < tipoUsuarios.Length; cont++)
            {
                resposta.Add(new
                {
                    id = valorUsuarios[cont],
                    nome = tipoUsuarios[cont]
                });
            }

            return Ok(resposta);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Busca")]
    public async Task<ActionResult> Busca(string filtro, [FromHeader(Name = "Usuario-Id")] int usuarioId)
    {
        try
        {
            var retornoBusca = await _usuarioAplicacao.Busca(filtro, usuarioId);
            var usuariosBusca = retornoBusca.Select(usuario => new UsuarioResposta()
            {
                Id = usuario.ID,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuario = usuario.TipoUsuario
            }).ToList();

            return Ok(usuariosBusca);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ListarDropUsuarios")]
    public async Task<ActionResult> ListarDropUsuarios([FromHeader(Name = "Usuario-Id")] int usuarioLoginId)
    {
        try
        {
            var usuarios = await _usuarioAplicacao.ListarDropUsuarios(usuarioLoginId);
            var resposta = usuarios.Select(u => new { id = u.ID, nome = u.Nome }).ToList();
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}