using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio.Entidades;

namespace Projeto360.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoAplicacao _projetoAplicacao;

        public ProjetoController(IProjetoAplicacao projetoAplicacao)
        {
            _projetoAplicacao = projetoAplicacao;
        }

        [HttpPost("Criar")]
        public async Task<ActionResult> Criar([FromBody] Projeto projeto)
        {
            try
            {
                var id = await _projetoAplicacao.Criar(projeto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public async Task<ActionResult Listar()
        {
            try
            {
                var projetos = await _projetoAplicacao.Listar();
                return Ok(projetos);
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
                var projeto = await _projetoAplicacao.Obter(id);
                return Ok(projeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] Projeto projeto)
        {
            try
            {
                await _projetoAplicacao.Atualizar(projeto);
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
                await _projetoAplicacao.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}