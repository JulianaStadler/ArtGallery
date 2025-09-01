using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ArtGallery.UseCases.CreateAccount;
using ArtGallery.UseCases.User.SearchUser;
using ArtGallery.UseCases.CreateAccount;
using ArtGallery.UseCases.User.CreatePost;
using ArtGallery.UseCases.User.DeleteAccount;
using ArtGallery.UseCases.User.EditAccount;
using ArtGallery.UseCases.User.FollowTag;
using ArtGallery.UseCases.User.FollowUser;
using ArtGallery.UseCases.User.SearchUser;
using ArtGallery.UseCases.User.SeeFeed;
using ArtGallery.UseCases.User.SeePost;
using ArtGallery.UseCases.User.UnFollowTag;
using ArtGallery.UseCases.User.UnFollowUser;

namespace ArtGallery.Endpoints;

public static class UsersEndpoints
{
    public static void ConfigurePostEndpoints(this WebApplication app)
    {
        // -------------------------- CREATE ACCOUNT -------------------------- //
        app.MapPost("users", async (
            [FromBody] CreateAccountPayload payload,
            [FromServices] CreateAccountUseCase useCase
        ) =>
        {
            return Results.Ok();
        });

        // --------------------- SEARCH ALL USERS ----------------------- //
        app.MapGet("/users/", async (
            [FromBody] CreateAccountPayload payload,
            [FromServices] CreateAccountUseCase useCase
        ) =>
        {
            return Results.Ok();
        });

        // --------------------- SEARCH USER ------------------------ //
        app.MapGet("/users/{id}", async (
            Guid id,
            [FromServices] SearchUserUseCase useCase,
            [FromServices] IUserService thisUserExist
        ) =>
        {
            return Results.Ok();
        });


        // ----------------------- EDIT ACCOUNT ------------------------- //
        app.MapPatch("/users/{id}", async (
            Guid id,
            HttpContext http,
            [FromBody] EditAccountPayload payload,
            [FromServices] EditAccountUseCase useCase
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();


        // ---------------------- DELETE ACCOUNT ------------------------ //
        app.MapDelete("/users/{id}", async (
            Guid id,
            HttpContext http,
            [FromServices] DeleteAccountUseCase useCase
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();


        // ----------------------- FOLLOW USER -------------------------- //
        app.MapPut("/users/{id}/follow/{otherUserId}", async (
            Guid id,
            Guid otherId,
            [FromServices] FollowUserUseCase useCase,
            [FromServices] IUserService thisUserExist
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();


        // ---------------------- UNFOLLOW USER ------------------------- //
        app.MapDelete("/users/{id}/follow/{otherUserId}", async (
            Guid id,
            Guid otherId,
            [FromServices] FollowUserUseCase useCase,
            [FromServices] IUserService thisUserExist
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();



        // ------------------------ FOLLOW TAG -------------------------- //
        app.MapPost("/users/{id}/tag/{tagId}", async (
            Guid id,
            Guid tagId,
            [FromServices] FollowTagUseCase useCase
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();


        // ----------------------- UNFOLLOW TAG ------------------------- //
        app.MapDelete("/users/{id}/tag/{tagId}", async (
            Guid id,
            Guid tagId,
            [FromServices] UnFollowTagUseCase useCase
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();


        // ----------------------- CREATE POST ----------------------- //
        app.MapPost("/users/{id}/posts", async (
            Guid id,
            HttpContext http,
            [FromBody] CreatePostPayload payload,
            [FromServices] CreatePostUseCase useCase
        ) =>
        {
            return Results.Ok();
        }).RequireAuthorization();
        
        

    }
}
