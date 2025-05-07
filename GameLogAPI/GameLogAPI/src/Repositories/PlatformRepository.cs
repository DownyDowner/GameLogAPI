﻿using GameLogAPI.src.Data;
using GameLogAPI.src.Entities;
using GameLogAPI.src.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GameLogAPI.src.Repositories {
    public class PlatformRepository(GameDbContext context) : IPlatformRepository {
        public async Task<Guid> AddAsync(Platform entity, CancellationToken ct) {
            await context.Platforms.AddAsync(entity, ct);
            await context.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct) {
            var platform = await context.Platforms
                .FirstOrDefaultAsync(x => x.Id == id, ct);

            if (platform == null)
                throw new ServiceException($"Platform with ID {id} was not found.", StatusCodes.Status404NotFound);

            context.Platforms.Remove(platform);
            await context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<Platform>> GetAllAsync(CancellationToken ct) {
            return await context.Platforms
                .OrderBy(e => e.Name)
                .ToListAsync(ct);
        }

        public async Task<Platform> GetByIdAsync(Guid id, CancellationToken ct) {
            var platform = await context.Platforms
                .Include(x => x.Games)
                .FirstOrDefaultAsync(x => x.Id == id, ct);

            if (platform == null)
                throw new ServiceException($"Platform with ID {id} was not found.", StatusCodes.Status404NotFound);

            return platform;
        }

        public async Task UpdateAsync(Platform entity, CancellationToken ct) {
            context.Update(entity);
            await context.SaveChangesAsync(ct);
        }
    }
}
