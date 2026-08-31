using Microsoft.Extensions.ObjectPool;
using Projeto360.Api.Models.Requisicao;
using Projeto360.Dominio.Entidades;

namespace Projeto360.Api.Models.Resposta;

public class ProjetoReposta
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Ativo { get; set; }


}