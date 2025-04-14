using GameLogAPI.src.Data;
using GameLogAPI.src.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Platform>> GetAllAsync(CancellationToken ct) {
            return await context.Platforms
                .ToListAsync(ct);
        }

        public async Task<Platform?> GetByIdAsync(Guid id, CancellationToken ct) {
            return await context.Platforms
                .Include(x => x.Games)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
