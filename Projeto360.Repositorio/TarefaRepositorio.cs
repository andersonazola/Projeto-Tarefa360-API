using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Repositorio;

public class TarefaRepositorio : BaseRepositorio, ITarefaRepositorio
{
    public TarefaRepositorio(Projeto360Contexto contexto) : base(contexto)
    {

    }
    public async Task<int> Salvar(Tarefa tarefa)
    {
        await _contexto.Tarefas.AddAsync(tarefa);
        await _contexto.SaveChangesAsync();
        return tarefa.ID;
    }

    public async Task Atualizar(Tarefa tarefa)
    {
        _contexto.Tarefas.Update(tarefa);
        await _contexto.SaveChangesAsync();
    }

    public async Task Deletar(Tarefa tarefa)
    {
        _contexto.Tarefas.Remove(tarefa);
        await _contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<Tarefa>> Listar(bool? concluida)
    {
        return await _contexto.Tarefas
        .Where(tarefa => concluida == null || tarefa.Concluida == concluida)
        .ToListAsync();
    }

    public async Task<Tarefa> Obter(int tarefaId)
    {
        return await _contexto.Tarefas.Where(t => t.ID == tarefaId).FirstOrDefaultAsync();
    }

}