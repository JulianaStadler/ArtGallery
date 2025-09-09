using ArtGallery.Models;

namespace ArtGallery.Services.Users;

public interface IUserService
{
    Task<User?> thisUserExist(Guid id);
    Task<bool> thisUsernameIsInUse(string username);
}