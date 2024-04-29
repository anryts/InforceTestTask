using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoGallery.Server.Data.Entities;

namespace PhotoGallery.Server.Data.DataConfiguration;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(album => album.Id);

        builder.Property(album => album.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(album => album.Images)
            .WithOne(image => image.Album);


    }
}