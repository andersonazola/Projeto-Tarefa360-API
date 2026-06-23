using Microsoft.AspNetCore.Mvc;
using Projeto360.Dominio.Entidades;
using Projeto360.Api.Models.Requisicao;
using Projeto360.Api.Models.Resposta;
using Projeto360.Aplicacao;
using Projeto360.Api.Models.Tarefas.Resposta;




namespace Projeto360.Api;

[ApiController]
[Route("[controller]")]

public class TarefaController : ControllerBase
{

    private readonly ITarefaAplicacao _tarefaAplicacao;

    public TarefaController(ITarefaAplicacao tarefaAplicacao)
    {
        _tarefaAplicacao = tarefaAplicacao;
    }


    [HttpGet]
    [Route("Listar")]
    public ActionResult Get( )
    {
        try
        {
            var tarefas = _tarefaAplicacao.ListarTarefas();
            var tarefaResposta =  tarefas.Select(tarefa => new TarefaResposta{
                ID = tarefa.ID,
                Nome = tarefa.Nome,
                Completa = tarefa.Completa
            });
            return Ok(tarefaResposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }









}