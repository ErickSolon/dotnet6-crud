using DotnetEstudo.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetEstudo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produtos> Produtos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
