using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Server.Data.Entities;

namespace PhotoGallery.Server.Data;

public class PhotoGalleryDbContext(DbContextOptions options) : IdentityDbContext<User,IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Image> Images { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<LikeToImage> Likes  { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}