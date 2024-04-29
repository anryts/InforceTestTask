using PhotoGallery.Server.Models.RequestModels;
using PhotoGallery.Server.Models.ResponseModels;

namespace PhotoGallery.Server.Services.Interfaces;

/// <summary>
/// Service for managing images.
/// </summary>
public interface IImageService
{
    Task<IEnumerable<ImageResponseModel>> GetImagesAsync(GetImagesRelatedToAlbumRequestModel model);
    Task<IEnumerable<ImageResponseModel>> GetImagesAsync(GetImagesRelatedToUserRequestModel model);
    Task<ImageResponseModel> CreateImage(CreateImageRequestModel model, IFormFile file);
}