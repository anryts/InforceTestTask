using PhotoGallery.Server.Models.RequestModels;
using PhotoGallery.Server.Models.ResponseModels;

namespace PhotoGallery.Server.Services.Interfaces;

public interface IAlbumService
{
    Task<IEnumerable<AlbumResponseModel>> GetAlbumsAsync(AlbumRequestModels model);
    Task<AlbumResponseModel> CreateAlbumAsync(CreateAlbumRequestModel model);
    Task<AlbumWithImagesResponseModel> GetAlbumAsync(Guid albumId);
    Task<IEnumerable<AlbumResponseModel>> GetAlbumsRelatedToUserAsync(AlbumRequestModels model);
}