using Instagram.Service.FollowAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services.FollowAPI.Data {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Follow> Follow { get; set; }
    }
}
