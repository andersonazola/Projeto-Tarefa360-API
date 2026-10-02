using Microsoft.EntityFrameworkCore;
using Projeto360.Dominio.Entidades;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Repositorio
{
    public class ProjetoRepositorio : BaseRepositorio, IProjetoRepositorio
    {
        public ProjetoRepositorio(Projeto360Contexto contexto) : base(contexto)
        {

        }

        public async Task<int> Salvar(Projeto projeto)
        {
            await _contexto.Projetos.AddAsync(projeto);
            await _contexto.SaveChangesAsync();
            return projeto.Id;
        }

        public async Task Atualizar(Projeto projeto)
        {
            _contexto.Projetos.Update(projeto);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Projeto> Obter(int projetoId)
        {
            return await _contexto.Projetos
            .FirstOrDefaultAsync(p => p.Id == projetoId && p.Ativo);
        }

        public async Task<IEnumerable<Projeto>> Listar(bool ativo = true)
        {
            return await _contexto.Projetos
            .Where(p => p.Ativo == ativo)
            .ToListAsync();
        }

        public async Task<IEnumerable<Projeto>> Busca(string filtro, bool ativo = true)
        {
            var resultadoBusca = _contexto.Projetos.Where(projeto => projeto.Ativo == ativo);

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtroLower = filtro.ToLower();
                resultadoBusca = resultadoBusca.Where(projeto =>
                    projeto.Nome.ToLower().Contains(filtroLower) ||
                    projeto.Descricao.ToLower().Contains(filtroLower)
                );
            }

            return await resultadoBusca.ToListAsync();
        }
    }
}