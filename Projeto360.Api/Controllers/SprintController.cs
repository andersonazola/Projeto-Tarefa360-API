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

    public class SprintController : ControllerBase
    {
        private readonly ISprintAplicacao _sprintAplicacao;

        public SprintController (ISprintAplicacao sprintAplicacao)
        {
            _sprintAplicacao = sprintAplicacao;
        }

        [HttpPost("Criar")]
        public async Task <ActionResult> Criar([FromBody] SprintCriar sprint)
        {
            try
            {
                var sprintDominio = new Sprint()
                {
                    Nome = sprint.Nome,
                    ProjetoId = sprint.ProjetoId,
                    DataInicio = sprint.DataInicio,
                    DataFim = sprint.DataFim
                };

                var usuarioId = await _sprintAplicacao.Criar(sprintDominio);
                return Ok (usuarioId);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
        
        [HttpGet("Listar")]
        public async Task<ActionResult> Listar (bool ativo)
        {
            try
            {
                var sprint = await _sprintAplicacao.Listar(ativo);
                return Ok (sprint);
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
                var sprintDominio = await _sprintAplicacao.Obter(id);

                var sprint = new SprintResposta()
                {
                    Id = sprintDominio.Id,
                    Nome = sprintDominio.Nome,
                    ProjetoId = sprintDominio.ProjetoId,
                    DataInicio = sprintDominio.DataInicio,
                    DataFim = sprintDominio.DataFim,
                };

                return Ok(sprint);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] SprintAtualizar sprint)
        {
            try
            {
                var sprintDominio = new Sprint()
                {
                    Id = sprint.Id,
                    Nome = sprint.Nome,
                    ProjetoId = sprint.ProjetoId,
                    DataInicio = sprint.DataInicio,
                    DataFim = sprint.DataFim
                };

                await _sprintAplicacao.Atualizar(sprintDominio);
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
                await _sprintAplicacao.Deletar(id);
                return Ok();
            }

            catch (Exception excecao)
            {
                return BadRequest (excecao.Message);
            }
        }
    }
}   