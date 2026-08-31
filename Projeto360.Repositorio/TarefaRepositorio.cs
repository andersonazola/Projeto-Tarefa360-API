using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Projeto360.Dominio.Entidades;
using Projeto360.Dominio.Enumeradores;
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
        tarefa.Ativa = false;
        _contexto.Tarefas.Update(tarefa);
        await _contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<Tarefa>> Listar(bool? concluida)
    {
        return await _contexto.Tarefas
        .Where(tarefa => concluida == null || tarefa.Concluida == concluida)
        .Include(tarefa => tarefa.Usuario)
        .Include(tarefa => tarefa.Projeto)
        .Include(tarefa => tarefa.Sprint)
        .Include(tarefa => tarefa.Historia)
        .ToListAsync();
    }

    public async Task<Tarefa> Obter(int tarefaId)
    {
        return await _contexto.Tarefas
        .Include(tarefa => tarefa.Usuario)
        .Include(tarefa => tarefa.Projeto)
        .Include(tarefa => tarefa.Sprint)
        .Include(tarefa => tarefa.Historia)
        .Where(tarefa => tarefa.ID == tarefaId).FirstOrDefaultAsync();
    }
    public async Task ConcluirTarefa(Tarefa tarefa)
    {
        tarefa.Concluida = true;
        _contexto.Update(tarefa);
        await _contexto.SaveChangesAsync();
    }

    public async Task <int> ContarTotalTarefas (int projetoId)
    {
        return await _contexto.Tarefas
            .CountAsync(t => t.Projeto.Id == projetoId);
    }

    public async Task<int> ContarTarefasConcluidas(int projetoId)
    {
        return await _contexto.Tarefas
            .CountAsync(t => t.ProjetoId == projetoId && t.Concluida == true);
    }

    public async Task<int> ContarTarefasAbertas(int projetoId)
    {
        return await _contexto.Tarefas
            .CountAsync(t => t.ProjetoId == projetoId && t.Concluida == false);
    }

    public async Task<int> ContarTotalBugs(int projetoId)
    {
        return await _contexto.Tarefas
            .CountAsync(t => t.ProjetoId == projetoId && t.TipoTarefas == TiposTarefas.Bug);
    }

    public async Task<int> ContarBugsFechados(int projetoId)
    {
        return await _contexto.Tarefas
            .CountAsync(t => t.ProjetoId == projetoId && t.TipoTarefas == TiposTarefas.Bug && t.Concluida == true);
    }

    public async Task<int> ContarBugsAbertos(int projetoId)
    {
        return await _contexto.Tarefas
            .CountAsync(t => t.ProjetoId == projetoId && t.TipoTarefas == TiposTarefas.Bug && t.Concluida == false);
    }
}