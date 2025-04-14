using FastEndpoints;
using GameLogAPI.src.Services;

namespace GameLogAPI.src.Features.Platforms {
    public class DeletePlatformEndpoint(PlatformService service) : Endpoint<DeletePlatformRequest> {
        public override void Configure() {
            Delete("platforms/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeletePlatformRequest req, CancellationToken ct) {
            try {
                await service.DeletePlatform(req.Id, ct);
                await SendNoContentAsync(ct);
            } catch (KeyNotFoundException) {
                await SendNotFoundAsync(ct);
            }
        }
    }

    public record DeletePlatformRequest(Guid Id);
}
