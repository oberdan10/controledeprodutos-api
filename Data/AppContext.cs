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
                .HasForeignKey(nota => nota.empresaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Empresa>()
                .HasMany(empresa => empresa.Cliente)
                .WithOne(cliente => cliente.Empresa)
                .HasForeignKey(nota => nota.empresaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Cliente>()
                .Property(cliente => cliente.tipoCliente)
                .HasConversion(
                conversao => conversao.ToString(),
                conversao => (TipoCliente)Enum.Parse(typeof(TipoCliente), conversao)
                );

            builder.Entity<Cliente>()
                .Property(m => m.empresaId)
                .IsRequired(false);

        }

        public DbSet<Item> Itens { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
