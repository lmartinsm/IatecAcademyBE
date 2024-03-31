using AtividadeRPiatec.Models;
using Microsoft.EntityFrameworkCore;

namespace AtividadeRPiatec.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Livro> Livros { get; set; }
    }
}
