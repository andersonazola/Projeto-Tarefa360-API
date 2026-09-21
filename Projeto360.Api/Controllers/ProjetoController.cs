using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio.Entidades;
using Projeto360.Api.Models.Resposta;
using Projeto360.Api.Models.Requisicao;

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
        public async Task<ActionResult> Criar([FromBody] ProjetoCriar projeto)
        {
            try
            {
                var projetoDominio = new Projeto()
                {
                    Nome = projeto.Nome,
                    Descricao = projeto.Descricao,
                    Ativo = projeto.Ativo = true
                };


                var projetoId = await _projetoAplicacao.Criar(projetoDominio);
                return Ok(projetoDominio.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var projetos = await _projetoAplicacao.Listar();
                var resposta = projetos.Select(projeto => new ProjetoReposta()
                {
                    Id = projeto.Id,
                    Nome = projeto.Nome,
                    Descricao = projeto.Descricao,
                    Ativo = projeto.Ativo

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
                var projetos = await _projetoAplicacao.Obter(id);
                var resposta = new ProjetoReposta()
                {
                    Id = projetos.Id,
                    Nome = projetos.Nome,
                    Descricao = projetos.Descricao,
                    Ativo = projetos.Ativo
                };
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] ProjetoAtualizar projeto)
        {
            try
            {
                var projetoAtualizar = new Projeto()
                {
                    Id = projeto.Id,
                    Nome = projeto.Nome,
                    Descricao = projeto.Descricao

                };
                await _projetoAplicacao.Atualizar(projetoAtualizar);
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

        [HttpGet]
        [Route("Busca")]
        public async Task<ActionResult> Busca(string filtro)
        {
            try
            {
                var retornoBusca = await _projetoAplicacao.Busca(filtro);
                var projetosBusca = retornoBusca.Select(projeto => new ProjetoReposta()
                {
                    Id = projeto.Id,
                    Nome = projeto.Nome,
                    Descricao = projeto.Descricao
                }).ToList();

                return Ok(projetosBusca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}