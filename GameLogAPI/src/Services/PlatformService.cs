using GameLogAPI.src.Entities;
using GameLogAPI.src.Features.Platforms;
using GameLogAPI.src.Repositories;

namespace GameLogAPI.src.Services {
    public class PlatformService(IPlatformRepository repository) {
        internal async Task<Guid> AddPlatform(AddPlatformRequest req, CancellationToken ct) {
            var platform = new Platform { Name = req.Name };
            return await repository.AddAsync(platform, ct);
        }

        internal async Task<Platform?> GetPlatform(Guid id, CancellationToken ct) {
            return await repository.GetByIdAsync(id, ct);
        }

        internal async Task<IEnumerable<Platform>> GetPlatforms(CancellationToken ct) {
            return await repository.GetAllAsync(ct);
        }
    }
}
