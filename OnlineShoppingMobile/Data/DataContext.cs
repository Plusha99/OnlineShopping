using Microsoft.EntityFrameworkCore;
using OnlineShoppingMobile.Models;

namespace OnlineShoppingMobile.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<MobileProduct> Mobiles { get; set; }
    }
}

