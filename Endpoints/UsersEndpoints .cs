using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ArtGallery.UseCases.CreateAccount;
using ArtGallery.UseCases.User.SearchUser;
using ArtGallery.UseCases.Login;
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
using ArtGallery.Services.Posts;
using ArtGallery.Services.Users;

namespace ArtGallery.Endpoints;

public static class UsersEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        // ------------------------------- LOGIN ------------------------------ //
        app.MapPost("/login", async (
            [FromBody] LoginPayload payload,
            [FromServices] LoginUseCase useCase
        ) =>
        {
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(result.Reason),
                (false, "Invalid email or password") => Results.Unauthorized(),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };
        });

        // -------------------------- CREATE ACCOUNT -------------------------- //
        app.MapPost("/users", async (
            [FromBody] CreateAccountPayload payload,
            [FromServices] CreateAccountUseCase useCase
        ) =>
        {
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Error exemple") => Results.NotFound(result.Reason),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };
        });

        // --------------------- SEARCH USER ------------------------ //
        app.MapGet("/users/{id}", async (
            Guid id,
            [FromServices] SearchUserUseCase useCase,
            [FromServices] IUserService thisUserExist
        ) =>
        {
            var payload = new SearchUserPayload{ Id = id };
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(result.Reason),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };
        });


        // ----------------------- EDIT ACCOUNT ------------------------- //
        app.MapPatch("/users/{id}", async (
            Guid id,
            HttpContext http,
            [FromBody] EditAccountPayload payload,
            [FromServices] EditAccountUseCase useCase
        ) =>
        {
            // cheacar se usuario esta autenticado
            var checkUserJWT = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (checkUserJWT == null)
                return Results.Unauthorized(); // usuario nao autenticado
            Guid loggedUserId = Guid.Parse(checkUserJWT);

            // checar se o userid da acao e o mesmo do jwt
            if (payload.UserId != loggedUserId)
                return Results.Forbid(); // tentativa de editar outra conta


            var result = await useCase.Do(payload);
            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(result.Reason),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };

        }).RequireAuthorization();


        // ---------------------- DELETE ACCOUNT ------------------------ //
        app.MapDelete("/users/{id}", async (
            Guid id,
            HttpContext http,
            [FromServices] DeleteAccountUseCase useCase
        ) =>
        {
            // cheacar se usuario esta autenticado
            var checkUserJWT = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (checkUserJWT == null)
                return Results.Unauthorized();
            Guid loggedUserId = Guid.Parse(checkUserJWT);

            // checar se o userid da acao e o mesmo do jwt
            if (id != loggedUserId)
                return Results.Forbid();

            var result = await useCase.Do(new DeleteAccountPayload{ UserId = id });
            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(result.Reason),
                (false, _) => Results.BadRequest(result.Reason),
                (true, _) => Results.Ok(result.Data)
            };

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
