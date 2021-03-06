using Microsoft.EntityFrameworkCore;
using MvcAppCollect.Models;

namespace MvcAppCollect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Item> Items { get; set; }
        
        public DbSet<User> Users { get; set; }
    }
}
