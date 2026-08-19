using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;
using Projeto360.Repositorio;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Aplicacao;

public class TarefaAplicacao : ITarefaAplicacao
{

    private readonly ITarefaRepositorio _tarefaRepositorio;

    public TarefaAplicacao(ITarefaRepositorio tarefaRepositorio)
    {
        _tarefaRepositorio = tarefaRepositorio;
    }
    public async Task<int> Criar(Tarefa tarefa)
    {
        tarefa.validarNome();
        return await _tarefaRepositorio.Salvar(tarefa);
    }

    public async Task Atualizar(Tarefa tarefa)
    {
        var tarefaExistente = await _tarefaRepositorio.Obter(tarefa.ID);
        if (tarefaExistente == null)
        {
            throw new Exception("Tarefa não encontrada!");
        }
        if (string.IsNullOrEmpty(tarefa.Nome))
        {
            throw new Exception("Nome da tarefa é obrigatório");
        }
        tarefaExistente.Nome = tarefa.Nome;
        tarefaExistente.Projeto = tarefa.Projeto;
        tarefaExistente.Descricao = tarefa.Descricao;

        await _tarefaRepositorio.Atualizar(tarefaExistente);
    }


    public async Task Deletar(int tarefaId)
    {
        var tarefa = await _tarefaRepositorio.Obter(tarefaId);
        if (tarefa == null)
        {
            throw new Exception("Tarefa não encontrada!");
        }
        await _tarefaRepositorio.Deletar(tarefa);
    }
    public async Task<Tarefa> Obter(int tarefaId)
    {
        return await _tarefaRepositorio.Obter(tarefaId);
    }

    public async Task<IEnumerable<Tarefa>> ListarTodasTarefas()
    {
        return await _tarefaRepositorio.Listar(null);
    }

    public async Task<IEnumerable<Tarefa>>Listar(bool concluida)
    {
        return await _tarefaRepositorio.Listar(concluida);
    }

    public async Task ConcluirTarefa(int TarefaId)
    {
        var tarefa = await _tarefaRepositorio.Obter(TarefaId);
        tarefa.Concluida = true;
        await _tarefaRepositorio.Atualizar(tarefa);
    }


}