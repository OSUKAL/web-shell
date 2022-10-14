namespace WebShell.Infrastructure.Repositories;

public interface ICommandRepository<T> : IDisposable
    where T : class
{
    Task<IEnumerable<T>> GetEntityListAsync();
    void PostEntity(T entity);
}