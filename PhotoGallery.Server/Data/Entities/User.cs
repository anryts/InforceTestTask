using Microsoft.AspNetCore.Identity;

namespace PhotoGallery.Server.Data.Entities;

public class User : IdentityUser<Guid>
{
    // public Guid Id { get; init; }
    // public string Email { get; init; } = null!;
    // public string FirstName { get; init; } = null!;
    // public string? LastName { get; init; }
    //
    // public string Password { get; init; } = null!;

    public IEnumerable<Album> Albums { get; init; } = new List<Album>();
    public IEnumerable<Image> Images { get; init; } = new List<Image>();
    public IEnumerable<LikeToImage> LikeToImages { get; set; } = new List<LikeToImage>();
    //public IEnumerable<IdentityUser> IdentityUsers { get; set; } = new List<IdentityUser>();
}