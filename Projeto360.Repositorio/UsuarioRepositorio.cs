using Projeto360.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Projeto360.Repositorio;

public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
{
    public UsuarioRepositorio(Projeto360Contexto contexto) : base(contexto)
    {

    }

    public async Task<int> Salvar(Usuario usuario)
    {
        _contexto.Usuarios.Add(usuario);
        _contexto.SaveChanges();
        return usuario.ID;
    }


    public async Task Atualizar(Usuario usuario)
    {
        _contexto.Usuarios.Update(usuario);
        await _contexto.SaveChangesAsync();
    }


    public async Task<Usuario> Obter(int usuarioId)
    {
        return await _contexto.Usuarios.Where(u => u.ID == usuarioId && u.Ativo).FirstOrDefaultAsync();
    }

    public async Task<Usuario> ObterPorId(int usuarioId)
    {
        return await _contexto.Usuarios.Where(u => u.ID == usuarioId)
                                .FirstOrDefaultAsync();
    }

    public async Task<Usuario> ObterEmail(string email)
    {
        return await _contexto.Usuarios.Where(u => u.Email == email && u.Ativo).FirstOrDefaultAsync();
    }


    public async Task<IEnumerable<Usuario>> Listar(bool ativo)
    {
        return await _contexto.Usuarios.Where(U => U.Ativo == ativo).ToListAsync();
    }

    public async Task<IEnumerable<Usuario>> Busca(string filtro, bool ativo = true)
    {
        var resultadoBusca = _contexto.Usuarios.Where(usuario => usuario.Ativo == ativo);

        if (!string.IsNullOrWhiteSpace(filtro))
        {
            var filtroLower = filtro.ToLower();
            resultadoBusca = resultadoBusca.Where(usuario =>
                usuario.Nome.ToLower().Contains(filtroLower) || usuario.Email.ToLower().Contains(filtroLower)
            );
        }

        return await resultadoBusca.ToListAsync();
    }
}
