using ArtGallery.Models;
using ArtGallery.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Services.Users;

public class UserService(ArtGalleryDbContext ctx) : IUserService
{
    public async Task<User?> thisUserExist(Guid id)
    {
        return await ctx.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
}