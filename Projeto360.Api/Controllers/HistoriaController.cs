using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Projeto360.Api.Models.Requisicao;
using Projeto360.Api.Models.Resposta;
using Projeto360.Aplicacao.Interfaces;
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
                    Descricao = historia.Descricao,
                    Ativo = historia.Ativo
                    
                };

                var historiaId = await _historiaAplicacao.Criar(historiaDominio);
                return Ok(historiaDominio.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public async Task<ActionResult> Listar(bool ativo)
        {
            try
            {
                var historias = await _historiaAplicacao.Listar(ativo);

                var resposta = historias.Select(historia => new HistoriaResposta()
                {
                    Id = historia.Id,
                    Nome = historia.Nome,
                    ProjetoId = historia.ProjetoId,
                    NomeProjeto = historia.Projeto.Nome,
                    Descricao = historia.Descricao,
                    Ativo = historia.Ativo
                });
                return Ok(resposta.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                    NomeProjeto = historiaDominio.Projeto.Nome,
                    Descricao = historiaDominio.Descricao,
                    Ativo = historiaDominio.Ativo

                };

                return Ok(historia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Busca")]
        public async Task<ActionResult> Busca(string filtro)
        {
            try
            {
                var retornoBusca = await _historiaAplicacao.Busca(filtro);
                var historiasBusca = retornoBusca.Select(historia => new HistoriaResposta()
                {
                    Id = historia.Id,
                    Nome = historia.Nome,
                    NomeProjeto = historia.Projeto.Nome,
                    ProjetoId = historia.ProjetoId,
                    Descricao = historia.Descricao,
                    Ativo = historia.Ativo
                }).ToList();

                return Ok(historiasBusca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}