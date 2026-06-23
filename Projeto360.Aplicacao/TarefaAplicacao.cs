using System.Collections.Generic;
using Projeto360.Dominio.Entidades;
using Projeto360.Servicos.Interfaces;

namespace Projeto360.Aplicacao;

public class TarefaAplicacao : ITarefaAplicacao
{
    private readonly IJsonPlaceHolderServico _jsonPlaceHolderServico;


    public TarefaAplicacao(IJsonPlaceHolderServico jsonPlaceHolderServico)
    {
        _jsonPlaceHolderServico = jsonPlaceHolderServico;
    }

    public List<Tarefa> ListarTarefas()
    {
        return _jsonPlaceHolderServico.ListarTarefas().Result;
    }
}