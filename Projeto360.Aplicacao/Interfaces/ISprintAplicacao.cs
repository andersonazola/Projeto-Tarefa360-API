using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;
using System.Collections.Generic;
using Projeto360.Entidades;

namespace Projeto360.Aplicacao.Interfaces;

public interface ISprintAplicacao
{
    Task<int> Criar(Sprint sprint);
    Task Atualizar(Sprint sprint);
    Task Deletar(int sprintId);
    Task<Sprint> Obter(int sprintId);
    Task<IEnumerable<Sprint>> Listar(bool ativo);
}