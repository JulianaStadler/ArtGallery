using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ArtGallery.UseCases.CreateAccount;
using ArtGallery.UseCases.User.SearchUser;

namespace ArtGallery.Endpoints;

public static class UsersEndpoints
{
    public static void ConfigurePostEndpoints(this WebApplication app)
    {
        // -------------------------- CRIAR USUARIO -------------------------- //
        // POST: /users
        app.MapPost("users", async (
            [FromBody] CreateAccountPayload payload,
            [FromServices] CreateAccountUseCase useCase
        ) =>
        {
            // TODO: Implementar lógica para publicar post
            return Results.Ok();
        });


        // --------------------- SEARCH USER ------------------------ //
        // GET: /users/search/{name}
        app.MapGet("users/search/{name}", (
            string name,
            [FromServices] SearchUserUseCase useCase
        ) =>
        {
            // TODO: Implementar lógica para obter post por ID
            return Results.Ok();
        });


        // ---------------------  ------------------------ //
        // PUT: /post/{id} (atualização completa)
        app.MapPut("post/{id}", async (
            string id,
            [FromBody] object payload, // Substituir pelo tipo correto (ex: UpdatePostPayload)
            HttpContext http,
            [FromServices] object useCase // Substituir pelo tipo correto (ex: UpdatePostUseCase)
        ) =>
        {
            // TODO: Implementar lógica para atualizar post completo
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim != null ? Guid.Parse(claim.Value) : Guid.Empty;

            return Results.Ok();
        }).RequireAuthorization();

        // PATCH: /post/{id} (atualização parcial)
        app.MapPatch("post/{id}", async (
            string id,
            [FromBody] object payload, // Substituir pelo tipo correto (ex: PatchPostPayload)
            HttpContext http,
            [FromServices] object useCase // Substituir pelo tipo correto (ex: PatchPostUseCase)
        ) =>
        {
            // TODO: Implementar lógica para atualização parcial do post
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim != null ? Guid.Parse(claim.Value) : Guid.Empty;

            return Results.Ok();
        }).RequireAuthorization();

        // DELETE: /post/{id}
        app.MapDelete("post/{id}", async (
            string id,
            HttpContext http,
            [FromServices] object useCase // Substituir pelo tipo correto (ex: DeletePostUseCase)
        ) =>
        {
            // TODO: Implementar lógica para deletar post
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim != null ? Guid.Parse(claim.Value) : Guid.Empty;

            return Results.Ok();
        }).RequireAuthorization();
    }
}
