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
                .HasForeignKey(item => item.categoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Empresa>()
                .HasMany(empresa => empresa.Funcionario)
                .WithOne(funcionario => funcionario.Empresa)
                .HasForeignKey(funcionario => funcionario.empresaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Empresa>()
                .HasMany(empresa => empresa.Nota)
                .WithOne(nota => nota.Empresa)
                .HasForeignKey(nota => nota.empresaId);

        }

        public DbSet<Item> Itens { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Nota> Notas { get; set; }
    }
}
