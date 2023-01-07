using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaPieShop.Models
{
    public class PieShopDbContext : DbContext
    {
        public PieShopDbContext(DbContextOptions<PieShopDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        ///add-migration InitalMigration
        ///update-database 
        ///add-migration AddTableShoppingCartItem
        /////update-database
    }
}

