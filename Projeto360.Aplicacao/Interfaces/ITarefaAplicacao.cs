using System.Collections.Generic;
using Projeto360.Dominio.Entidades;
namespace Projeto360.Aplicacao;

public interface ITarefaAplicacao
{
    List<Tarefa> ListarTarefas();
}