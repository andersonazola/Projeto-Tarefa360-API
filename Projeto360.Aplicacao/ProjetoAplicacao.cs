using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio.Entidades;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Aplicacao
{
    public class ProjetoAplicacao : IProjetoAplicacao
    {
        private readonly IProjetoRepositorio _projetoRepositorio;

        public ProjetoAplicacao(IProjetoRepositorio projetoRepositorio)
        {
            _projetoRepositorio = projetoRepositorio;
        }

        public async Task<int> Criar(Projeto projeto)
        {
            if (projeto == null)
                throw new Exception("Projeto não pode ser vazio!");

            if (string.IsNullOrEmpty(projeto.Nome))
                throw new Exception("Nome do projeto é obrigatório!");

            return await _projetoRepositorio.Salvar(projeto);    
        }

        public async Task Atualizar(Projeto projeto)
        {
            var projetoExistente = await _projetoRepositorio.Obter(projeto.Id);
            if (projetoExistente == null)
                throw new Exception("Projeto não encontrado!");

            if (string.IsNullOrEmpty(projeto.Nome))
                throw new Exception("Nome do projeto é obrigatório!");

            projetoExistente.Nome = projeto.Nome;
            projetoExistente.Descricao = projeto.Descricao;

            await _projetoRepositorio.Atualizar(projetoExistente);
        }

        public async Task Deletar(int projetoId)
        {
            var projeto = await _projetoRepositorio.Obter(projetoId);
            if (projeto == null)
                throw new Exception("Projeto não econtrado!");

            projeto.Deletar();
            await _projetoRepositorio.Atualizar(projeto);
        }

        public async Task<Projeto> Obter(int projetoId)
        {
            return await _projetoRepositorio.Obter(projetoId);
        }

        public async Task<IEnumerable<Projeto>> Listar(bool ativo = true)
        {
            return await _projetoRepositorio.Listar(ativo);
        }
    }
}