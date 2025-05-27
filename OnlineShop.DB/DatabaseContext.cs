using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;

namespace OnlineShop.DB
{
    public class DatabaseContext:DbContext
    {
        public DbSet<ProductDB> ProductDBs { get; set; }
        public DbSet<CartDb> CartDbs { get; set; }
        public DbSet<CartItemDb> CartItemBds { get; set; }

        public DatabaseContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}