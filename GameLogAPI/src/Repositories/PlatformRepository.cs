using GameLogAPI.src.Data;
using GameLogAPI.src.Entities;

namespace GameLogAPI.src.Repositories {
    public class PlatformRepository(GameDbContext context) : IPlatformRepository {
        public async Task<Guid> AddAsync(Platform entity, CancellationToken ct) {
            await context.Platforms.AddAsync(entity, ct);
            await context.SaveChangesAsync(ct);
            return entity.Id;
        }

        public Task DeleteAsync(Guid id, CancellationToken ct) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Platform>> GetAllAsync(CancellationToken ct) {
            throw new NotImplementedException();
        }

        public Task<Platform?> GetByIdAsync(Guid id, CancellationToken ct) {
            throw new NotImplementedException();
        }
    }
}
