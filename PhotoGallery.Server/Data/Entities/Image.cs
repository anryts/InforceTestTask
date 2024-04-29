namespace PhotoGallery.Server.Data.Entities;

public class Image
{
    public Guid Id { get; init; }
    public string Title { get; init; } = null!;
    public string ImagePath { get; init; } = null!;
    public Guid CreatorId { get; set; }
    public Guid AlbumId { get; set; }
    
    public IEnumerable<LikeToImage> Likes { get; init; } = new List<LikeToImage>();
    public User? User { get; set; }
    public Album? Album { get; set; }
}