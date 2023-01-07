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
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        ///add-migration InitalMigration
        ///update-database 
        ///add-migration AddTableShoppingCartItem
        /////update-database
        /////add-migration AddTableOrderAndOrderDetails
        ////////update-database
    }
}

