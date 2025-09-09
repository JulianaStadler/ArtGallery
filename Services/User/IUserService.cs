using ArtGallery.Models;

namespace ArtGallery.Services.Users;

public interface IUserService
{
    Task<User?> thisUserExist(Guid id);
<<<<<<< HEAD
    Task<bool> thisUsernameIsInUse(string username);
=======
    Task<User> FindByLogin(string login);
>>>>>>> 3d209cf (commit :))
}