using FastEndpoints;

namespace GameLogAPI.src.Features.Games {
    public class AddGameEndpoint(GameService service) : Endpoint<AddGameRequest> {
        public override void Configure() {
            Post("games");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddGameRequest req, CancellationToken ct) {
            var id = await service.AddGame(req, ct);
            await SendCreatedAtAsync<GetGameEndpoint>(new { id }, null, cancellation: ct);
        }
    }

    public record AddGameRequest(string Title, string Platform);
}
