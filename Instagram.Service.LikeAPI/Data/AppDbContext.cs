using Instagram.Service.LikeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services.LikeAPI.Data {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PostLike> PostLike { get; set; }
        public DbSet<CommentLike> CommentLike { get; set; }
    }
}
