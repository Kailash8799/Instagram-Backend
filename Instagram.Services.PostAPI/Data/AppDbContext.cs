using Instagram.Services.PostAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services.PostAPI.Data {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Post> Post { get; set; }
    }
}
