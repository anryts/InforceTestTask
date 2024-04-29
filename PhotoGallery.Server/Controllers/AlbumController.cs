using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Server.Models.RequestModels;
using PhotoGallery.Server.Services.Interfaces;

namespace PhotoGallery.Server.Controllers;

[Route("api/[controller]")]
[ApiController, Authorize]
public class AlbumController(IAlbumService service) : ControllerBase
{

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAlbums([FromQuery]AlbumRequestModels model)
    {
        return Ok(await service.GetAlbumsAsync(model));
    }

    [HttpGet("album_current_user")]
    public async Task<IActionResult> GetAlbumsRelatedToUser([FromQuery]AlbumRequestModels model)
    {
        return Ok(await service.GetAlbumsRelatedToUserAsync(model));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAlbum(CreateAlbumRequestModel model)
    {
        return Ok(await service.CreateAlbumAsync(model));
    }

    /// <summary>
    /// Delete an album with all related images
    /// </summary>
    /// <param name="albumId"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteAlbum(Guid albumId)
    {
        throw new NotImplementedException();
    }
}