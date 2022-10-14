using Microsoft.EntityFrameworkCore;
using WebShell.Infrastructure.Data;

namespace WebShell.Infrastructure.Repositories;

public class UnitOfWork : IDisposable
{
    private readonly AppDbContext _context;

    private bool _disposed;

    public UnitOfWork(DbContextOptions<AppDbContext> options)
    {
        _context = new AppDbContext(options);
        CommandRepository = new CommandRepository(_context);
    }

    public CommandRepository CommandRepository { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}