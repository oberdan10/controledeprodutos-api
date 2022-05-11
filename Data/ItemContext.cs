using ControleDeProdutos_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeProdutos_API.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext (DbContextOptions<ItemContext> opt) : base(opt)
        {


        }

        public DbSet<Item> Itens { get; set; }
    }
}
