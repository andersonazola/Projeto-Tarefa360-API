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

        //terminar a parte de aplicacao e perguntar como vou fazer

        public async Task Atualizar (Sprint sprint)
        {
            var sprintExistente = await _sprintRepositorio.Obter(sprint.Id);

            if ()
        }
    }
}