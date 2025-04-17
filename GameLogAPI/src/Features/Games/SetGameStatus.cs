using FastEndpoints;
using GameLogAPI.src.Entities;
using GameLogAPI.src.Services;

namespace GameLogAPI.src.Features.Games {
    public class SetGameStatusToPlannedEndpoint(GameService service) : EndpointWithoutRequest {
        public override void Configure() {
            Patch("games/{id:guid}/planned");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct) {
            try {
                var id = Route<Guid>("id");
                await service.UpdateGameStatus(id, GameStatus.Planned, ct);
                await SendNoContentAsync(ct);
            } catch (KeyNotFoundException) {
                await SendNotFoundAsync(ct);
            }
        }
    }

    public class SetGameStatusToPlayingEndpoint(GameService service) : EndpointWithoutRequest {
        public override void Configure() {
            Patch("games/{id:guid}/playing");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct) {
            try {
                var id = Route<Guid>("id");
                await service.UpdateGameStatus(id, GameStatus.Playing, ct);
                await SendNoContentAsync(ct);
            } catch (KeyNotFoundException) {
                await SendNotFoundAsync(ct);
            }
        }
    }
}
