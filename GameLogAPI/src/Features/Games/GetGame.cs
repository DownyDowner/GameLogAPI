using FastEndpoints;
using GameLogAPI.src.Entities;
using GameLogAPI.src.Services;

namespace GameLogAPI.src.Features.Games {
    public class GetGameEndpoint(GameService service) : Endpoint<GetGameRequest, GetGameResponse> {
        public override void Configure() {
            Get("games/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetGameRequest req, CancellationToken ct) {
            var game = await service.GetGame(req.Id, ct);
            if (game == null) {
                await SendNotFoundAsync(ct);
                return;
            }
            await SendOkAsync(new GetGameResponse(
                Id: game.Id,
                Title: game.Title,
                Platform: game.Platform!.Name,
                ReleaseDate: game.ReleaseDate,
                Status: game.Status,
                Rating: game.Rating,
                Review: game.Review,
                StartedOn: game.StartedOn,
                CompletedOn: game.CompletedOn
            ), ct);
        }
    }

    public record GetGameRequest(Guid Id);
    public record GetGameResponse(Guid Id, string Title, string Platform, DateOnly ReleaseDate, GameStatus Status, int? Rating, string? Review, DateTime? StartedOn, DateTime? CompletedOn);
}
