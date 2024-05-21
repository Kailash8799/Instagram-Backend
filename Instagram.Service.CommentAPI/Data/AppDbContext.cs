using Instagram.Services.CommentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services.CommentAPI.Data {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Comment> Comment { get; set; }
    }
}
