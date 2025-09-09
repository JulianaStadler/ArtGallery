using ArtGallery.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Services.Users;

public class UserService(ArtGalleryDbContext ctx) : IUserService
{
    public async Task<User?> thisUserExist(Guid id)
    {
        return await ctx.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

<<<<<<< HEAD
    public async Task<bool> thisUsernameIsInUse(string username)
    {
        var thisUsernameIsInUse = await ctx.Users.FirstOrDefaultAsync(u => u.Name == username);    
        return thisUsernameIsInUse != null ? true : false ;
=======
    public async Task<User> FindByLogin(string login)
    {
        var user = await ctx.Users.FirstOrDefaultAsync(
            p => p.Name == login || p.Email == login
        );
        return user;
>>>>>>> 3d209cf (commit :))
    }
}