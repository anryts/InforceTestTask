using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoGallery.Server.Data.Entities;

namespace PhotoGallery.Server.Data.DataConfiguration;

public class LikeToImageConfiguration : IEntityTypeConfiguration<LikeToImage>
{
    public void Configure(EntityTypeBuilder<LikeToImage> builder)
    {
        builder.HasKey(x => new { x.ImageId, x.UserId });
    }
}