using Microsoft.EntityFrameworkCore;
using WebShell.Domain.Models;
using WebShell.Infrastructure.Data;

namespace WebShell.Infrastructure.Repositories;

public class CommandRepository : ICommandRepository<CommandModel>
{
    private readonly AppDbContext _context;

    private bool _disposed;

    public CommandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CommandModel>> GetEntityListAsync()
    {
        return await _context.Commands.OrderByDescending(x => x.Id).Take(20).ToListAsync();
    }

    public void PostEntity(CommandModel command)
    {
        _context.Commands.Add(command);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}