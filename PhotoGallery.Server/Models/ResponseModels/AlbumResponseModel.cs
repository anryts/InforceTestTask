namespace PhotoGallery.Server.Models.ResponseModels;

public record AlbumResponseModel(Guid id, string Name, string CoverImageUrl);

public record AlbumWithImagesResponseModel(Guid Id, string Name, string CoverImageUrl, IEnumerable<ImageResponseModel> Images);