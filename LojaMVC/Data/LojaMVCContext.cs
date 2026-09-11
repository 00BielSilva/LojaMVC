using LojaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaMVC.Data
{
    public class LojaMVCContext:DbContext
    {
        public LojaMVCContext(DbContextOptions<LojaMVCContext> options):base(options)
        {
            
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
