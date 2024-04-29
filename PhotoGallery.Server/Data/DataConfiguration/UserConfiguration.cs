using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoGallery.Server.Data.Entities;

namespace PhotoGallery.Server.Data.DataConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        // builder.Property(user => user.FirstName)
        //     .IsRequired()
        //     .HasMaxLength(50);
        //
        // builder.Property(user => user.LastName)
        //     .HasMaxLength(50);
        //
        // builder.Property(user => user.Email)
        //     .IsRequired()
        //     .HasMaxLength(100);
        //
        // builder.Property(user => user.Password)
        //     .IsRequired()
        //     .HasMaxLength(250);

        // builder.HasIndex(user => user.Email)
        //     .IsUnique();

        builder.HasMany(user => user.Images)
            .WithOne(image => image.User);

        builder.HasMany(user => user.Albums)
            .WithOne(album => album.User);

        builder.HasMany(user => user.LikeToImages)
            .WithOne(likeToImage => likeToImage.User);
    }
}