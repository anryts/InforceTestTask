using System.Net;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Server.Data;
using PhotoGallery.Server.Data.Entities;
using PhotoGallery.Server.Enums;
using PhotoGallery.Server.Exceptions;
using PhotoGallery.Server.Models.RequestModels;
using PhotoGallery.Server.Models.ResponseModels;
using PhotoGallery.Server.Services.Interfaces;

namespace PhotoGallery.Server.Services;

/// <summary>
/// Service for managing images.
/// </summary>
/// <param name="fileService"></param>
public class ImageService (IFileService fileService, PhotoGalleryDbContext context, ICurrentUserService currentUserService)
    : IImageService
{
    /// <summary>
    /// Get images related to an album.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<ImageResponseModel>> GetImagesAsync(GetImagesRelatedToAlbumRequestModel model)
    {
        var images = await context.Images.Where(image => image.AlbumId == model.AlbumId)
                .ToListAsync();
        return images
            .Select(image => new ImageResponseModel(image.Id, image.ImagePath.Replace("\\", "/"), image.Title));
    }

    /// <summary>
    /// Get images related to a user.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<ImageResponseModel>> GetImagesAsync(GetImagesRelatedToUserRequestModel model)
    {
        var images = await context.Images.Where(image => image.CreatorId == model.UserId)
            .AsNoTracking()
            .ToListAsync();
        return images
            .Select(image => new ImageResponseModel(image.Id, image.ImagePath, image.Title));
    }

    /// <summary>
    /// Create an image. with uploaded file and assigned to an album.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ImageResponseModel> CreateImage(CreateImageRequestModel model, IFormFile file)
    {
        var filePath = await fileService.SaveFileAsync(file, file.FileName,
            currentUserService.GetCurrentUserId());

        var album = await context.Albums.FirstOrDefaultAsync(album => album.Id == model.AlbumId) ??
                throw new BaseException("Album not found",HttpStatusCode.NotFound, ErrorCode.AlbumNotFound);

        var image = new Image
        {
            Id = Guid.NewGuid(),
            ImagePath = filePath,
            AlbumId = model.AlbumId,
            Title = model.Title,
            CreatorId = currentUserService.GetCurrentUserId()
        };

        if (string.IsNullOrWhiteSpace(album.ThumbnailImage))
            album.ThumbnailImage = image.ImagePath;


        await context.Images.AddAsync(image);
        context.Albums.Update(album);
        await context.SaveChangesAsync();

        return new ImageResponseModel(image.Id, image.ImagePath, image.Title);
    }
}