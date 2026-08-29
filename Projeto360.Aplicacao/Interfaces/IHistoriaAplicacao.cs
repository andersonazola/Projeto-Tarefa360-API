using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;
using System.Collections.Generic;
using Projeto360.Entidades;

namespace Projeto360.Aplicacao.Interfaces
{
    public interface IHistoriaAplicacao
    {
        Task<int> Criar(Historia historia);
        Task Atualizar(Historia historia);
        Task Deletar(int historiaId);
        Task<Historia> Obter(int historiaId);
        Task<IEnumerable<Historia>> Listar(bool ativo);
    }
}