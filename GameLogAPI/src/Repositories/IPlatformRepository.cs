using GameLogAPI.src.Entities;

namespace GameLogAPI.src.Repositories {
    public interface IPlatformRepository : IRepository<Platform> {
        public Task UpdateNameAsync(Guid id, string name, CancellationToken ct);
    }
}
