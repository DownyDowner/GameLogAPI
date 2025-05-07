using GameLogAPI.src.Entities;
using GameLogAPI.src.Exceptions;
using GameLogAPI.src.Features.Platforms;
using GameLogAPI.src.Repositories;

namespace GameLogAPI.src.Services {
    public class PlatformService(IPlatformRepository repository) {
        internal async Task<Guid> AddPlatform(AddPlatformRequest req, CancellationToken ct) {
            var platform = new Platform { Name = req.Name };
            return await repository.AddAsync(platform, ct);
        }

        internal async Task DeletePlatform(Guid id, CancellationToken ct) {
            await repository.DeleteAsync(id, ct);
        }

        internal async Task<Platform> GetPlatform(Guid id, CancellationToken ct) {
            return await repository.GetByIdAsync(id, ct);
        }

        internal async Task<IEnumerable<Platform>> GetPlatforms(CancellationToken ct) {
            return await repository.GetAllAsync(ct);
        }

        internal async Task UpdatePlatform(UpdatePlatformRequest req, CancellationToken ct) {
            var platform = await repository.GetByIdAsync(req.Id, ct);
            if (platform == null) 
                throw new ServiceException($"Platform with ID {req.Id} was not found.", StatusCodes.Status404NotFound);
            platform.Name = req.Name;
            await repository.UpdateAsync(platform, ct);
        }
    }
}
