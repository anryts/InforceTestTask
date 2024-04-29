namespace PhotoGallery.Server.Data.Entities;

public class LikeToImage
{
    public Guid ImageId { get; set; }
    public Guid UserId { get; set; }
    /// <summary>
    /// True - yes, False - no
    /// </summary>
    public bool IsLike { get; set; }

    public User? User { get; set; }
    public Image? Image { get; set; }
}