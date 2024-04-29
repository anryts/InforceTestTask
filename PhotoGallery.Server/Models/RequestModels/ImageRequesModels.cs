namespace PhotoGallery.Server.Models.RequestModels;

public record GetImagesRelatedToAlbumRequestModel(Guid AlbumId, int AmountOfImages, int Offset);
public record GetImageRequestModel(Guid ImageId);
public record GetImagesRelatedToUserRequestModel(Guid UserId, int AmountOfImages, int Offset);

public record CreateImageRequestModel(string Title, Guid AlbumId);