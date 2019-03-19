using fpReceitas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace fpReceitas.Core.Contexts
{
    public class ReceitaContext : DbContext
    {
        public ReceitaContext(DbContextOptions<ReceitaContext> options)
            : base(options)
        { }

        public DbSet<Receita> Receitas { get; set; }
    }
}
