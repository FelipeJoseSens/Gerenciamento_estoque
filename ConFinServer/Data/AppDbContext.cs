using ConFinServer.Model;
using Microsoft.EntityFrameworkCore;

namespace ConFinServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                            :base(options)
        {

        }

        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Conta> Conta { get; set; }
    }
}
