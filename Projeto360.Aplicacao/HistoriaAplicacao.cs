using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio.Entidades;
using Projeto360.Entidades;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Aplicacao
{
    public class HistoriaAplicacao : IHistoriaAplicacao
    {
        private readonly IHistoriaRepositorio _historiaRepositorio;

        public HistoriaAplicacao(IHistoriaRepositorio historiaRepositorio)
        {
            _historiaRepositorio = historiaRepositorio;
        }

        public async Task<int> Criar (Historia historia)
        {
            if (historia == null)
            {
                throw new Exception("História não pode ser vazia!");
            }

            if (string.IsNullOrEmpty(historia.Nome))
            {
                throw new Exception("Nome da história é obrigatório!");
            }

            return await _historiaRepositorio.Salvar(historia);    
        }

        public async Task Atualizar(Historia historia)
        {
            var historiaExistente = await _historiaRepositorio.Obter(historia.Id);

            if (historiaExistente == null)
            {
                throw new Exception("História não encontrada!");
            }

            if (string.IsNullOrEmpty(historia.Nome))
            {
                throw new Exception("Nome da história é obrigatório!");
            }

            historiaExistente.Nome = historia.Nome;
            historiaExistente.Projeto = historia.Projeto;
            historiaExistente.Descricao = historia.Descricao;

            await _historiaRepositorio.Atualizar(historiaExistente);
        }

        public async Task Deletar(int historiaId)
        {
            var historia = await _historiaRepositorio.Obter(historiaId);

            if (historia == null)
            {
                throw new Exception("História não encontrada!");
            }

            await _historiaRepositorio.Deletar(historia);
        }

        public async Task<Historia> Obter(int historiaId)
        {
            return await _historiaRepositorio.Obter(historiaId);
        }

        public async Task<IEnumerable<Historia>> Listar(bool ativo)
        {
            return await _historiaRepositorio.Listar(ativo);
        }
    }
}