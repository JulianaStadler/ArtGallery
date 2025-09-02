using ArtGallery.Models;

namespace ArtGallery.Services.Posts;

public interface IPostService
{
    Task<Post?> thisPostExist(Guid id);
}