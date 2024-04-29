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
/// Service for managing albums.
/// </summary>
public class AlbumService(PhotoGalleryDbContext context, ICurrentUserService currentUserService)
    : IAlbumService
{
    public async Task<IEnumerable<AlbumResponseModel>> GetAlbumsAsync(AlbumRequestModels model)
    {
        var albums = await context.Albums
            .Skip(model.Offset)
            .Take(model.AmountOfAlbums)
            .ToListAsync();


        return albums
            .Select(album => new AlbumResponseModel(album.Id, album.Title, album.ThumbnailImage ?? string.Empty));
    }

    public async Task<AlbumResponseModel> CreateAlbumAsync(CreateAlbumRequestModel model)
    {
        //TODO: validation
        var album = new Album
        {
            Id = Guid.NewGuid(),
            Title = model.AlbumName,
            CreatorId = currentUserService.GetCurrentUserId(),
            ThumbnailImage = string.Empty
        };

        await context.Albums.AddAsync(album);
        await context.SaveChangesAsync();

        return new AlbumResponseModel(album.Id, album.Title, album.ThumbnailImage);
    }

    public async Task<AlbumWithImagesResponseModel> GetAlbumAsync(Guid albumId)
    {
        var album = await context.Albums
            .Include(album => album.Images)
            .FirstOrDefaultAsync(album => album.Id == albumId)
        ?? throw new BaseException("Album not found", HttpStatusCode.NotFound, ErrorCode.AlbumNotFound);

        //TODO: possibility to add likes and
        return new AlbumWithImagesResponseModel(album.Id, album.Title, album.ThumbnailImage ?? string.Empty,
            album.Images.Select(image => new ImageResponseModel(image.Id, image.ImagePath, image.Title)));
    }

    public async Task<IEnumerable<AlbumResponseModel>> GetAlbumsRelatedToUserAsync(AlbumRequestModels model)
    {
        var userId = currentUserService.GetCurrentUserId();

        var albums = await context.Albums
            .Where(album => album.CreatorId == userId)
            .Skip(model.Offset)
            .Take(model.AmountOfAlbums)
            .ToListAsync();

        return albums
            .Select(album => new AlbumResponseModel(album.Id, album.Title, album.ThumbnailImage ?? string.Empty));
    }
}