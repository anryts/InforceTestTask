namespace PhotoGallery.Server.Services.Interfaces;

public interface ICurrentUserService
{
    Guid GetCurrentUserId();
}