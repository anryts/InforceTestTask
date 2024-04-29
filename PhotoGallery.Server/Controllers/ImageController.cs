using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PhotoGallery.Server.Data.Entities;
using PhotoGallery.Server.Models.RequestModels;
using PhotoGallery.Server.Services.Interfaces;

namespace PhotoGallery.Server.Controllers;

/// <summary>
/// Controller for image operations
/// </summary>
/// <param name="fileService"></param>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ImageController(IImageService service) : ControllerBase
{
    /// <summary>
    /// Get all images related to album
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("{albumId:Guid}"), AllowAnonymous]
    public async Task<IActionResult> GetImagesRelated(Guid albumId, int amountOfImages, int offset)
    {
        return Ok(await service
            .GetImagesAsync(new GetImagesRelatedToAlbumRequestModel(albumId,amountOfImages, offset)));
    }

    /// <summary>
    /// Upload an image
    /// </summary>
    /// <returns></returns>
    [HttpPost("{albumId:Guid}")]
    public async Task<IActionResult> UploadImage(Guid albumId, IFormFile file, string title)
    {
        return Ok(await service.CreateImage(new CreateImageRequestModel(title, albumId), file));
    }

    /// <summary>
    /// Add like/dislike to image
    /// </summary>
    /// <param name="imageId"></param>
    /// <param name="isLike">true - like, false - dislike</param>
    /// <returns></returns>
    [HttpPost("like")]
    public async Task<IActionResult> AddLike(Guid imageId, bool isLike)
    {
        throw new NotImplementedException();
    }
}