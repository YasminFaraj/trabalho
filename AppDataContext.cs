using Microsoft.EntityFrameworkCore;
using trabalho.Models;

namespace trabalho.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Folha> Folhas { get; set; }
    }
}
