using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;
using System.Collections.Generic;


namespace Projeto360.Aplicacao.Interfaces
{
    public interface IProjetoAplicacao
    {
        Task <int> Criar(Projeto projeto);
        Task Atualizar (Projeto projeto);
        Task Deletar (int projetoId);
        Task<Projeto> Obter(int projetoId);
        Task<IEnumerable<Projeto>> Listar (bool ativo = true);
    }
}