using FastEndpoints;
using FluentValidation;
using GameLogAPI.src.Services;

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

    public record AddGameRequest(string Title, string Platform, DateOnly ReleaseDate);

    public class AddGameRequestValidator : Validator<AddGameRequest> {
        public AddGameRequestValidator() {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Platform)
                .NotEmpty();

            RuleFor(x => x.ReleaseDate)
                .NotEmpty();
        }
    }
}
