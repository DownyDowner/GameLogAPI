using FastEndpoints;
using GameLogAPI.src.Services;

namespace GameLogAPI.src.Features.Games {
    public class GetGamesCompletedEndpoint(GameService service) : EndpointWithoutRequest<IEnumerable<GetGamesCompletedResponse>> {
        public override void Configure() {
            Get("games/completed");
            AllowAnonymous();
        }

        public override async Task<IEnumerable<GetGamesCompletedResponse>> ExecuteAsync(CancellationToken ct) {
            var games = await service.GetGamesCompleted(ct);
            return games.Select(e => new GetGamesCompletedResponse(e.Id, e.Title, e.Platform!.Name, e.ReleaseDate, e.CompletedOn!.Value));
        }
    }

    public record GetGamesCompletedResponse(Guid Id, string Title, string Platform, DateOnly ReleaseDate, DateTime CompletedOn);
}
