using Microsoft.EntityFrameworkCore;
using chamadosTeste.Models;

namespace chamadosTeste.data
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext> options)
            : base(options)
        {
        }

        public DbSet<Acoes> Acoes { get; set; }
        public DbSet<Chamado> Chamado { get; set; }        
  
    }
}
