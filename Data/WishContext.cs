using Microsoft.EntityFrameworkCore;
using WishAPI.Models;

namespace WishAPI.Data
{
    public class WishContext : DbContext
    {
        public WishContext(DbContextOptions<WishContext> opt) : base(opt)
        {

        }

        public DbSet<Wish> Wishes { get; set; }
    }
}
