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
        tarefaExistente.Descricao = tarefa.Descricao;
        tarefaExistente.Concluida = tarefa.Concluida;
        tarefaExistente.Ativa = tarefa.Ativa;
        tarefaExistente.ProjetoId = tarefa.ProjetoId;
        tarefaExistente.SprintId = tarefa.SprintId;
        tarefaExistente.HistoriaId = tarefa.HistoriaId;
        tarefaExistente.UsuarioId = tarefa.UsuarioId;
        tarefaExistente.TipoTarefas = tarefa.TipoTarefas;

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

    public async Task<IEnumerable<Tarefa>> Listar(bool concluida)
    {
        return await _tarefaRepositorio.Listar(concluida);
    }

    public async Task<IEnumerable<Tarefa>> Busca(string filtro, bool ativo = true)
    {
        return await _tarefaRepositorio.Busca(filtro, ativo);
    }

    public async Task ConcluirTarefa(int id)
    {

        var tarefa = await _tarefaRepositorio.Obter(id);
        if (tarefa.Ativa == false)
        {
            throw new ArgumentException("Não é possivel concluir uma tarefa que não esteja ativa");
        }
        if (tarefa.Concluida == true)
        {
            throw new Exception("Essa tarefa ja foi concluida antes!");
        }
        await _tarefaRepositorio.ConcluirTarefa(tarefa);
        Console.WriteLine("Tarefa concluida com sucesso!");
    }

}