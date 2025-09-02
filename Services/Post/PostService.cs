using ArtGallery.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Services.Posts;

public class PostService(ArtGalleryDbContext ctx) : IPostService
{
    public async Task<Post?> thisPostExist(Guid id)
    {
        return await ctx.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }
}