using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PhotoGallery.Server.Controllers;
using PhotoGallery.Server.Models.RequestModels;
using PhotoGallery.Server.Models.ResponseModels;
using PhotoGallery.Server.Services.Interfaces;
using Xunit;

namespace PhotoGallery.Tests;

public class ImageControllerTests
{
    [Fact]
    public async Task GetImagesRelated_ReturnsOkObjectResult_WithImages()
    {
        // Arrange
        var mockService = new Mock<IImageService>();
        var testAlbumId = Guid.NewGuid();
        mockService.Setup(service => service.GetImagesAsync(It.IsAny<GetImagesRelatedToAlbumRequestModel>()))
            .ReturnsAsync(new List<ImageResponseModel>
                { new ImageResponseModel(Guid.NewGuid(), "path/to/image.jpg", "Sample Image") });
        var controller = new ImageController(mockService.Object);

        // Act
        var result = await controller.GetImagesRelated(testAlbumId, 10, 0);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<ImageResponseModel>>(okResult.Value);
        Assert.Single(returnValue);
    }

    [Fact]
    public async Task UploadImage_ReturnsOkObjectResult_WhenFileIsUploadedSuccessfully()
    {
        // Arrange
        var mockService = new Mock<IImageService>();
        var testAlbumId = Guid.NewGuid();
        var fileMock = new Mock<IFormFile>();
        var fileName = "test.jpg";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write("image content");
        writer.Flush();
        ms.Position = 0;
        fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
        fileMock.Setup(_ => _.FileName).Returns(fileName);
        fileMock.Setup(_ => _.Length).Returns(ms.Length);

        mockService.Setup(service => service.CreateImage(It.IsAny<CreateImageRequestModel>(), It.IsAny<IFormFile>()))
            .ReturnsAsync(new ImageResponseModel(Guid.NewGuid(), "path/to/image.jpg", "Sample Image"));

        var controller = new ImageController(mockService.Object);

        // Act
        var result = await controller.UploadImage(testAlbumId, fileMock.Object, "Test Image");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ImageResponseModel>(okResult.Value);
        Assert.Equal("Sample Image", returnValue.Name);
        Assert.Equal("path/to/image.jpg", returnValue.Url);
    }
}