namespace PhotoGallery.Server.Models.ResponseModels;

public record UserSignInResponseModel(string AuthToken, string RefreshToken);