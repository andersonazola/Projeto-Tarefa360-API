using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Projeto360.Api.Models.Requisicao;
using Projeto360.Api.Models.Resposta;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;


namespace Projeto360.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class HistoriaController : ControllerBase
    {
        private readonly IHistoriaAplicacao _historiaAplicacao;

        public HistoriaController(IHistoriaAplicacao historiaAplicacao)
        {
            _historiaAplicacao = historiaAplicacao;
        }

        [HttpPost("Criar")]
        public async Task<ActionResult> Criar([FromBody] HistoriaCriar historia)
        {
            try
            {
                var historiaDominio = new Historia()
                {
                    Nome = historia.Nome,
                    ProjetoId = historia.ProjetoId,
                    Descricao = historia.Descricao
                };

                var usuarioId = await _historiaAplicacao.Criar(historiaDominio);
                return Ok(usuarioId);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpGet("Listar")]
        public async Task<ActionResult> Listar(bool ativo)
        {
            try
            {
                var historia = await _historiaAplicacao.Listar(ativo);
                return Ok(historia);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpGet("Obter/{id}")]
        public async Task<ActionResult> Obter([FromRoute] int id)
        {
            try
            {
                var historiaDominio = await _historiaAplicacao.Obter(id);

                var historia = new HistoriaResposta()
                {
                    Id = historiaDominio.Id,
                    Nome = historiaDominio.Nome,
                    ProjetoId = historiaDominio.ProjetoId,
                    Descricao = historiaDominio.Descricao
                };

                return Ok(historia);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] HistoriaAtualizar historia)
        {
            try
            {
                var historiaDominio = new Historia()
                {
                    Id = historia.Id,
                    Nome = historia.Nome,
                    ProjetoId = historia.ProjetoId,
                    Descricao = historia.Descricao
                };

                await _historiaAplicacao.Atualizar(historiaDominio);
                return Ok();
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<ActionResult> Deletar([FromRoute] int id)
        {
            try
            {
                await _historiaAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}