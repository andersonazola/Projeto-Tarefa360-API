using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;
using Projeto360.Sprint.Interfaces;
namespace Projeto360.Sprint
{
    public class SprintRepositorio : BaseRepositorio, ISprintRepositorio
    { 
        public SprintRepositorio(Projeto360Contexto contexto) : base(contexto)
        {
            
        }

        public async Task <int> Salvar (Sprint sprint)
        {
            sprint.Validar;
            await _contexto.Sprints.AddAsync(sprint);
            await _contexto.SaveChangesAsync();
            return sprint.Id;
        }

        public async Task Atualizar (Sprint sprint)
        {
            _contexto.Sprints.Update(sprint);
            await _contexto.SaveChangesAsync();
        }

        public async Task <Sprint> Obter (int sprintId)
        {
            return await _contexto.Sprints
                .FirstOrDefaultAsync (sprint => sprintId == sprintId && sprint.Ativo);
        }

        public async Task Deletar (Sprint sprint)
        {
            sprint.Ativo = false;
            _contexto.Sprints.Update(sprint);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sprint>>Listar(bool ativo)
        {
            return await _contexto.Sprints
            .Where(sprint => sprint.Ativo == ativo)
            .ToListAsync();
        }
    }
}