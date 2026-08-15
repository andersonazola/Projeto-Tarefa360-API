using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Repositorio
{
    public class HistoriaRepositorio : BaseRepositorio, IHistoriaRepositorio
    {
        public HistoriaRepositorio(Projeto360Contexto contexto) : base(contexto)
        {

        }

        public async Task<int> Salvar(Historia historia)
        {
            await _contexto.Historias.AddAsync(historia);
            await _contexto.SaveChangesAsync();
            return historia.Id;
        } 

        public async Task Atualizar(Historia historia)
        {
            _contexto.Historias.Update(historia);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Historia> Obter(int historiaId)
        {
            return await _contexto.Historias
                .FirstOrDefaultAsync(historia => historia.Id == historiaId && historia.Ativo);
        }

        public async Task Deletar(Historia historia)
        {
            historia.Ativo = false;
            _contexto.Historias.Update(historia);
            await _contexto.SaveChangesAsync();
        }
        public async Task<IEnumerable<Historia>> Listar(bool ativo)
        {
            return await _contexto.Historias
                .Where(historia => historia.Ativo == ativo)
                .ToListAsync();
        }
    }
}