using FastEndpoints;
using GameLogAPI.src.Entities;

namespace GameLogAPI.src.Features.Games {
    public class GetGameEndpoint(GameService service) : Endpoint<GetGameRequest, GetGameResponse> {
        public override void Configure() {
            Get("games/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetGameRequest req, CancellationToken ct) {
            var game = await service.GetGame(req.Id);
            if (game == null) {
                await SendNotFoundAsync(ct);
                return;
            }
            await SendOkAsync(new GetGameResponse(
                Id: game.Id,
                Title: game.Title,
                Platform: game.Platform,
                Status: game.Status,
                Rating: game.Rating,
                Review: game.Review,
                StartedOn: game.StartedOn.HasValue ? DateOnly.FromDateTime(game.StartedOn.Value) : null,
                CompletedOn: game.CompletedOn.HasValue ? DateOnly.FromDateTime(game.CompletedOn.Value) : null
            ), ct);
        }
    }

    public record GetGameRequest(Guid Id);
    public record GetGameResponse(Guid Id, string Title, string Platform, GameStatus Status, int? Rating, string? Review, DateOnly? StartedOn, DateOnly? CompletedOn);
}
