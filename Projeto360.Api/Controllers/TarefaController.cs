using Microsoft.AspNetCore.Mvc;
using Projeto360.Api.Models.Requisicao;
using Projeto360.Api.Models.Resposta;
using Projeto360.Api.Models.Tarefas.Resposta;
using Projeto360.Aplicacao;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;
using SQLitePCL;

namespace Projeto360.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TarefaController : ControllerBase
    {
        private readonly ITarefaAplicacao _tarefaAplicacao;

        public TarefaController(ITarefaAplicacao tarefaAplicacao)
        {
            _tarefaAplicacao = tarefaAplicacao;
        }


        [HttpPost("Criar")]
        public async Task<ActionResult> Criar([FromBody] TarefaCriar tarefa)
        {
            try
            {
                var tarefaDominio = new Tarefa()
                {
                    Nome = tarefa.Nome,
                    Descricao = tarefa.Descricao,
                    TipoTarefas = tarefa.TiposTarefas,
                    ProjetoId = tarefa.ProjetoId,
                    HistoriaId = tarefa.HistoriaId,
                    SprintId = tarefa.SprintId,
                    UsuarioId = tarefa.UsuarioId

                };

                var tarefaId = await _tarefaAplicacao.Criar(tarefaDominio);
                return Ok(tarefaId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] TarefaAtualizar tarefa)
        {
            try
            {
                var tarefaDominio = new Tarefa()
                {
                    ID = tarefa.Id,
                    Nome = tarefa.Nome,
                    Descricao = tarefa.Descricao,
                    TipoTarefas = tarefa.TiposTarefas,
                    Concluida = tarefa.Concluida,
                    Ativa = tarefa.Ativa,
                    ProjetoId = tarefa.ProjetoId,
                    HistoriaId = tarefa.HistoriaId,
                    SprintId = tarefa.SprintId,
                    UsuarioId = tarefa.UsuarioId

                };

                await _tarefaAplicacao.Atualizar(tarefaDominio);
                return Ok();
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
                var tarefaDominio = await _tarefaAplicacao.Obter(id);

                var tarefa = new TarefaResposta()
                {
                    Id = tarefaDominio.ID,
                    Nome = tarefaDominio.Nome,
                    Descricao = tarefaDominio.Descricao,
                    TiposTarefas = tarefaDominio.TipoTarefas,
                    Concluida = tarefaDominio.Concluida,
                    Ativa = tarefaDominio.Ativa,

                    ProjetoId = tarefaDominio.ProjetoId,
                    NomeProjeto = tarefaDominio.Projeto.Nome,

                    HistoriaId = tarefaDominio.HistoriaId,
                    NomeHistoria = tarefaDominio.Historia.Nome,

                    SprintId = tarefaDominio.SprintId,
                    NomeSprint = tarefaDominio.Sprint.Nome,

                    UsuarioId = tarefaDominio.UsuarioId,
                    NomeUsuario = tarefaDominio.Usuario.Nome

                };
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Concluir/{id}")]
        public async Task<ActionResult> ConcluirTarefa(int id)
        {
            try
            {
                await _tarefaAplicacao.ConcluirTarefa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Listar")]
        public async Task<ActionResult> Listar(bool concluida)
        {
            try
            {
                var tarefa = await _tarefaAplicacao.Listar(concluida);
                var resposta = tarefa.Select(tarefa => new TarefaResposta()
                {
                    Id = tarefa.ID,
                    Nome = tarefa.Nome,
                    Descricao = tarefa.Descricao,
                    TiposTarefas = tarefa.TipoTarefas,
                    Concluida = tarefa.Concluida,
                    Ativa = tarefa.Ativa,

                    ProjetoId = tarefa.ProjetoId,
                    NomeProjeto = tarefa.Projeto.Nome,

                    HistoriaId = tarefa.HistoriaId,
                    NomeHistoria = tarefa.Historia.Nome,

                    SprintId = tarefa.SprintId,
                    NomeSprint = tarefa.Sprint.Nome,

                    UsuarioId = tarefa.UsuarioId,
                    NomeUsuario = tarefa.Usuario.Nome
                });
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("ListarTodas")]
        public async Task<ActionResult> ListarTodas()
        {
            try
            {
                var tarefa = await _tarefaAplicacao.ListarTodasTarefas();
                var resposta = tarefa.Select(tarefa => new TarefaResposta()
                {
                    Id = tarefa.ID,
                    Nome = tarefa.Nome,
                    Descricao = tarefa.Descricao,
                    TiposTarefas = tarefa.TipoTarefas,
                    Concluida = tarefa.Concluida,
                    Ativa = tarefa.Ativa,

                    ProjetoId = tarefa.ProjetoId,
                    NomeProjeto = tarefa.Projeto.Nome,

                    HistoriaId = tarefa.HistoriaId,
                    NomeHistoria = tarefa.Historia.Nome,

                    SprintId = tarefa.SprintId,
                    NomeSprint = tarefa.Sprint.Nome,

                    UsuarioId = tarefa.UsuarioId,
                    NomeUsuario = tarefa.Usuario.Nome
                });
                return Ok(resposta);
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
                await _tarefaAplicacao.Deletar(id);
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
                var retornoBusca = await _tarefaAplicacao.Busca(filtro);
                var tarefasBusca = retornoBusca.Select(tarefa => new TarefaResposta()
                {
                    Id = tarefa.ID,
                    Nome = tarefa.Nome,
                    Descricao = tarefa.Descricao,
                    NomeProjeto = tarefa.Projeto.Nome,
                    TiposTarefas = tarefa.TipoTarefas,
                    Concluida = tarefa.Concluida,
                    Ativa = tarefa.Ativa,
                    ProjetoId = tarefa.ProjetoId,
                    HistoriaId = tarefa.HistoriaId,
                    NomeHistoria = tarefa.Historia.Nome,
                    SprintId = tarefa.SprintId,
                    NomeSprint = tarefa.Sprint.Nome,
                    NomeUsuario = tarefa.Usuario.Nome,
                    UsuarioId = tarefa.UsuarioId

                }).ToList();

                return Ok(tarefasBusca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


