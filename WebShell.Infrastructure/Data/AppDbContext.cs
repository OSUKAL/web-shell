using Microsoft.EntityFrameworkCore;
using WebShell.Domain.Models;

namespace WebShell.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CommandModel> Commands => Set<CommandModel>();
    }
}
