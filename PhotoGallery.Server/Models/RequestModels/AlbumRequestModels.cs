namespace PhotoGallery.Server.Models.RequestModels;

public record AlbumRequestModels(int AmountOfAlbums, int Offset);

public record CreateAlbumRequestModel(string AlbumName);


