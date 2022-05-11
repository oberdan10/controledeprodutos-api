using ControleDeProdutos_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeProdutos_API.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> opt) : base(opt)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Categoria>()
                .HasMany(categoria => categoria.Item)
                .WithOne(item => item.Categoria)
                .HasForeignKey(item => item.categoriaId);
                }

        public DbSet<Item> Itens { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
