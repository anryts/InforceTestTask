using Microsoft.AspNetCore.Mvc;
using Moq;
using PhotoGallery.Server.Controllers;
using PhotoGallery.Server.Models.RequestModels;
using PhotoGallery.Server.Models.ResponseModels;
using PhotoGallery.Server.Services.Interfaces;
using Xunit;

namespace PhotoGallery.Tests;

public class AlbumControllerTests
{
    [Fact]
    public async Task GetAlbumsRelatedToUser_ReturnsOkObjectResult_WithAlbums()
    {
        // Arrange
        var mockService = new Mock<IAlbumService>();
        var userId = Guid.NewGuid();

        mockService.Setup(service => service.GetAlbumsRelatedToUserAsync(It.IsAny<AlbumRequestModels>()))
            .ReturnsAsync(new List<AlbumResponseModel>() { new AlbumResponseModel(Guid.NewGuid(), "User Album", "path/to/thumb.jpg") });

        var controller = new AlbumController(mockService.Object);

        // Act
        var result = await controller.GetAlbumsRelatedToUser(new AlbumRequestModels(5, 0));

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<AlbumResponseModel>>(okResult.Value);
        Assert.Single(returnValue);
        Assert.Equal("User Album", returnValue[0].Name);
    }
}