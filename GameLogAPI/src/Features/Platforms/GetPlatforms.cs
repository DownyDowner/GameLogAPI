using FastEndpoints;
using GameLogAPI.src.Services;

namespace GameLogAPI.src.Features.Platforms {
    public class GetPlatformsEndpoint(PlatformService service) : EndpointWithoutRequest<IEnumerable<GetPlatformsResponse>> {
        public override void Configure() {
            Get("platforms");
            AllowAnonymous();
        }

        public override async Task<IEnumerable<GetPlatformsResponse>> ExecuteAsync(CancellationToken ct) {
            var platforms = await service.GetPlatforms(ct);
            return platforms.Select(e => new GetPlatformsResponse(e.Id, e.Name));
        }
    }

    public record GetPlatformsResponse(Guid Id, string Name);
}
