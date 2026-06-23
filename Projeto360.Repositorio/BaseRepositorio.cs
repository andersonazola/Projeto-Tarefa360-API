public abstract class BaseRepositorio
{
    protected readonly Projeto360Contexto  _contexto;

    protected BaseRepositorio(Projeto360Contexto contexto)
    {
        _contexto = contexto;
    }
}