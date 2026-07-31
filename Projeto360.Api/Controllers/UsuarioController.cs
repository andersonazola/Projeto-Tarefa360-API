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
    public async Task<ActionResult> Obter([FromRoute] int usuarioId)
    {
        try
        {
            var usuarioDominio = await _usuarioAplicacao.Obter(usuarioId);
            var usuario = new UsuarioResposta()
            {
                Id = usuarioDominio.ID,
                Nome = usuarioDominio.Nome,
                Email = usuarioDominio.Email,
            };
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("Criar")]
    public async Task<ActionResult> Criar([FromBody] UsuarioCriar usuario)
    {
        try
        {
            var usuarioDominio = new Usuario()
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };
            var usuarioID = await _usuarioAplicacao.Criar(usuarioDominio);
            return Ok(usuarioID);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [HttpPut]
    [Route("Atualizar")]

    public async Task<ActionResult> Atualizar([FromBody] UsuarioAtualizar usuario)
    {
        try
        {
            var usuarioDominio = new Usuario()
            {
                ID = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
            await _usuarioAplicacao.Atualizar(usuarioDominio);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("AlterarSenha")]
    public async Task<ActionResult> AlterarSenha([FromBody] UsuarioAlterarSenha usuario)
    {
        try
        {
            var usuarioDominio = new Usuario()
            {
                ID = usuario.Id,
                Senha = usuario.Senha
            };
            await _usuarioAplicacao.AlterarSenha(usuarioDominio, usuario.SenhaAntiga);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("Deletar/{usuarioId}")]
    public async Task<ActionResult> Deletar([FromRoute] int usuarioId)
    {
        try
        {
            await _usuarioAplicacao.Deletar(usuarioId);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Restaurar/{usuarioId}")]
    public async Task<ActionResult> Restaurar([FromRoute] int usuarioId)
    {
        try
        {
            await _usuarioAplicacao.Restaurar(usuarioId);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Listar")]
    public async Task<ActionResult> List([FromQuery] bool ativos)
    {
        try
        {
            var usuarioDominio = await _usuarioAplicacao.Listar(ativos);
            var usuarios = usuarioDominio.Select(usuario => new UsuarioResposta()
            {
                Id = usuario.ID,
                Nome = usuario.Nome,
                Email = usuario.Email
            }).ToList();

            return Ok(usuarios);

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

}