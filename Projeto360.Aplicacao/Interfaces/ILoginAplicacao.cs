using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Projeto360.Dominio.Entidades;
using System.Collections.Generic;
using Projeto360.Entidades;

namespace Tarefa360.Aplicacao.Interfaces
{
    public interface ILoginAplicacao
    {
        Task<Usuario> Login(Usuario usuario);
    }
}