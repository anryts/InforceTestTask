namespace PhotoGallery.Server.Models.RequestModels;

public record UserCreateRequestModel(string Email, string FirstName, string LastName, string Password);
public record UserSignInRequestModel(string Email, string Password);
