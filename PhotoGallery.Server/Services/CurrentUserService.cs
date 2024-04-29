using Microsoft.IdentityModel.JsonWebTokens;
using PhotoGallery.Server.Services.Interfaces;

namespace PhotoGallery.Server.Services;

public class CurrentUserService : ICurrentUserService
{
    private Guid? _userId;
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public Guid GetCurrentUserId()
    {
        if (_userId.HasValue)
            return _userId.Value;

        _userId = GetUserIdFromClaims();
        return _userId!.Value;
    }

    private Guid? GetUserIdFromClaims()
    {
        var claims = _contextAccessor.HttpContext?.User.Claims.ToList()
                     ?? throw new Exception("Claim's wasn't founded");

        return new Guid(claims[0].Value);
    }
}