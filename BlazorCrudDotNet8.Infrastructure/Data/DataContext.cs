using BlazorCrudDotNet8.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}
