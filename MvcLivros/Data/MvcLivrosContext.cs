using Microsoft.EntityFrameworkCore;

namespace MvcLivros.Data
{
    public class MvcLivrosContext : DbContext
    {
        public MvcLivrosContext (DbContextOptions<MvcLivrosContext> options)
            : base(options)
        {
        }

        public DbSet<MvcLivros.Models.Livro> Livro { get; set; } = default!;
    }
}
