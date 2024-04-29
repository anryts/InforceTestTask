using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoGallery.Server.Data.Entities;

namespace PhotoGallery.Server.Data.DataConfiguration;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Likes)
            .WithOne(x => x.Image);
    }
}