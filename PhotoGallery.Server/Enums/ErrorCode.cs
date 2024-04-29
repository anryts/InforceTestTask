namespace PhotoGallery.Server.Enums;

public enum ErrorCode
{
    UserValidationFailed = 1000,
    UserAlreadyExists = 1001,
    UserNotFound = 1002,
    UserLoginFailed = 1003,
    UserNotAuthorized = 1004,

    InvalidPassword = 2000,

    AlbumNotFound = 3000,

    ImageNotFound = 4000,
}