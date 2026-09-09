using Microsoft.AspNetCore.Mvc;
using Projeto360.Api.Models.Dashboard.Resposta;
using Projeto360.Aplicacao.Interfaces;

namespace Projeto360.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardAplicacao _dashboardAplicacao;

        public DashboardController(IDashboardAplicacao dashboardAplicacao)
        {
            _dashboardAplicacao = dashboardAplicacao;
        }

        [HttpGet("Obter/{projetoId}")]
        public async Task<ActionResult> Obter([FromRoute] int projetoId)
        {
            try
            {
                var resumo = await _dashboardAplicacao.ObterDadosDashboard(projetoId);

                var resposta = new DashboardResposta()
                {
                    ProjetoId = resumo.ProjetoId,

                    TotalTarefas      = resumo.TotalTarefas,
                    TarefasConcluidas = resumo.TarefasConcluidas,
                    TarefasAbertas    = resumo.TarefasAbertas,

                    TotalHistorias    = resumo.TotalHistorias,
                    HistoriasFechadas = resumo.HistoriasFechadas,
                    HistoriasAbertas  = resumo.HistoriasAbertas,

                    TotalBugs    = resumo.TotalBugs,
                    BugsFechados = resumo.BugsFechados,
                    BugsAbertos  = resumo.BugsAbertos
                };

                return Ok(resposta);
            }
            catch (Exception excecao)
            {
                return BadRequest(excecao.Message);
            }
        }
    }
}