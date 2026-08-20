using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio.Entidades;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Aplicacao
{
    public class SprintAplicacao : ISprintAplicacao
    {
        private readonly ISprintRepositorio _sprintRepositorio;

        public SprintAplicacao (ISprintRepositorio sprintRepositorio)
        {
            _sprintRepositorio = sprintRepositorio;
        }

    

        public async Task <int> Criar (Sprint sprint)
        {
            if (sprint == null)
            {
                throw new Exception ("Sprint não pode ser vazia");
            }

            if (string.IsNullOrEmpty(sprint.Nome))
            {
                throw new Exception("Nome da sprint é obrigatório!");
            }

            return await _sprintRepositorio.Salvar(sprint);
        }


        public async Task Atualizar(Sprint sprint)
        {
            var sprintExistente = await_sprintRepositorio.Obter(sprint.Id);

            if (sprintExistente == null)
            {
                throw new Exception ("Sprint não encontrada!");
            }

            if (string.IsNullOrEmpty(sprint.Nome))
            {
                throw new Exception ("Nome da sprint é obrigatório!");
            }

            sprintExistente.Nome = sprint.Nome;
            sprintExistente.Projeto = sprint.Projeto;

            await _sprintRepositorio.Atualizar(sprintExistente);
        }

        public async Task Deletar (int sprintId)
        {
            var sprint = await _sprintRepositorio.Obter(sprintId);

            if (sprint == null)
            {
                throw new Exception ("Sprint não encontrada!");
            }

            await _sprintRepositorio.Deletar(sprint);
        }

        public async  Task<Sprint> Obter (int sprintId)
        {
            return await _sprintRepositorio.Obter(sprintId);
        }

        public async Task<IEnumerable<Sprint>> Listar (bool ativo)
        {
            return await _sprintRepositorio.Listar(ativo);
        }
    }
    
    }
