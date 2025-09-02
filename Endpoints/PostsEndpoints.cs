using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ArtGallery.UseCases.Post.Comment;
using ArtGallery.UseCases.Post.Delete;
using ArtGallery.UseCases.Post.DeleteComment;
using ArtGallery.UseCases.Post.Deslike;
using ArtGallery.UseCases.Post.Edit;
using ArtGallery.UseCases.Post.Like;
using ArtGallery.UseCases.User.SeeFeed;
using ArtGallery.UseCases.User.SeePost;
using ArtGallery.Services.Posts;
using ArtGallery.Services.Users;

namespace ArtGallery.Endpoints;

public static class PostsEndpoints
{
    public static void ConfigurePostEndpoints(this WebApplication app)
    {
        // ------------------------ EDIT POST ------------------------ //
        app.MapPatch("/users/{id}/posts/{postId}", async (
            Guid id,
            Guid postId,
            HttpContext http,
            [FromBody] EditPayload payload,
            [FromServices] EditUseCase useCase
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();


        // ----------------------- LIST POSTS ------------------------ //
        app.MapGet("/users/{id}/posts/", async (
            Guid id,
            [FromServices] SeeFeedUseCase useCase,
            [FromServices] IUserService thisUserExist
        ) =>
        {
            return Results.Ok();
        });


        // ------------------------ SHOW POST ----------------------- //
        app.MapGet("/users/{id}/posts/{postid}", async (
            Guid id,
            Guid postId,
            [FromServices] SeePostUseCase useCase,
            [FromServices] IUserService thisUserExist,
            [FromServices] IPostService thisPostExist
        ) =>
        {
            return Results.Ok();
        });


        // ----------------------- DELETE POST ----------------------- //
        app.MapDelete("/users/{id}/posts/{postid}", async (
            Guid id,
            Guid postId,
            HttpContext http,
            [FromServices] SeePostUseCase useCase,
            [FromServices] IUserService thisUserExist,
            [FromServices] IPostService thisPostExist
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();



        // // ---------------------- ADD POST TAG ----------------------- //
        // app.MapPost("/users/{id}/posts/{postid}/tags/{tagId}", async (
        //     Guid id,
        //     Guid postId,
        //     HttpContext http,
        //     [FromServices] TaUseCase useCase,
        //     [FromServices] IUserService thisUserExist,
        //     [FromServices] IPostService thisPostExist
        // ) =>
        // {
        //     return Results.Ok();
        // }).RequireAuthorization();


        // // --------------------- REMOVE POST TAG --------------------- //
        // app.MapDelete("/users/{id}/posts/{postid}/{tagId}", async (
        //     Guid id,
        //     Guid postId,
        //     HttpContext http,
        //     [FromServices] SeePostUseCase useCase,
        //     [FromServices] IUserService thisUserExist,
        //     [FromServices] IPostService thisPostExist
        // ) =>
        // {
        //     return Results.Ok();
        // }).RequireAuthorization();


        // ------------------------- COMMENT ------------------------- //
        app.MapPost("/users/{id}/posts/{postid}/comment/", async (
            Guid id,
            Guid postId,
            HttpContext http,
            [FromServices] CommentUseCase useCase,
            [FromServices] IUserService thisUserExist,
            [FromServices] IPostService thisPostExist
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();

        // --------------------- DELETE COMMENT ---------------------- //
        app.MapDelete("/users/{id}/posts/{postid}/{commentId}", async (
            Guid id,
            Guid postId,
            Guid commentId,
            HttpContext http,
            [FromServices] DeleteCommentUseCase useCase,
            [FromServices] IUserService thisUserExist,
            [FromServices] IPostService thisPostExist
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();

    }
}
