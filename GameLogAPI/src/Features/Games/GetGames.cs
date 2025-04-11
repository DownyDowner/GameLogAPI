using FastEndpoints;
using GameLogAPI.src.Services;

namespace GameLogAPI.src.Features.Games {
    public class GetGamesEndpoint(GameService service) : EndpointWithoutRequest<IEnumerable<GetGamesResponse>> {
        public override void Configure() {
            Get("games");
            AllowAnonymous();
        }

        public override async Task<IEnumerable<GetGamesResponse>> ExecuteAsync(CancellationToken ct) {
            var games = await service.GetGames(ct);
            return games.Select(e => new GetGamesResponse(e.Id, e.Title, e.Platform));
        }
    }

    public record GetGamesResponse(Guid Id, string Title,string Platform);
}
