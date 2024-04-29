
namespace PhotoGallery.Server.Data.Entities;

public class Album
{
    public Guid Id { get; init; }
    public string Title { get; init; } = null!;
    public string? ThumbnailImage { get; set; }
    public Guid CreatorId { get; set; }

    public IEnumerable<Image> Images { get; init; } = new List<Image>();

    public User? User { get; set; }
}