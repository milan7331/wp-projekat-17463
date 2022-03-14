using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<PCStore> Stores { get; set; }
        public DbSet<PCPart> Parts { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public StoreContext(DbContextOptions options) : base(options)
        {

        }
    }
}