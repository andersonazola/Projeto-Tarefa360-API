using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;
using Projeto360.Repositorio.Interfaces;
namespace Projeto360.Repositorio
{
    public class SprintRepositorio : BaseRepositorio, ISprintRepositorio
    { 
        public SprintRepositorio(Projeto360Contexto contexto) : base(contexto)
        {
            
        }

        public async Task <int> Salvar (Sprint sprint)
        {
            sprint.Validar();
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
                .Include(sprint => sprint.Projeto)
                .FirstOrDefaultAsync (sprint => sprint.Id == sprintId && sprint.Ativo);
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
            .Include(sprint => sprint.Projeto)
            .ToListAsync();
        }

        public async Task<IEnumerable<Sprint>> Busca(string filtro, bool ativo = true)
        {
            var resultadoBusca = _contexto.Sprints.Where(sprint => sprint.Ativo == ativo);

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtroLower = filtro.ToLower();
                resultadoBusca = resultadoBusca.Where(sprint =>
                    sprint.Nome.ToLower().Contains(filtroLower) || sprint.Projeto.Nome.ToLower().Contains(filtroLower)
                );
            }

           return await resultadoBusca.Include(sprint => sprint.Projeto).ToListAsync();
        }
    }
}