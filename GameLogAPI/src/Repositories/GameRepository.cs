﻿using GameLogAPI.src.Data;
using GameLogAPI.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameLogAPI.src.Repositories {
    public class GameRepository(GameDbContext context) : IGameRepository {

        public async Task<Guid> AddAsync(Game game, CancellationToken ct) {
            await context.Games.AddAsync(game, ct);
            await context.SaveChangesAsync(ct);
            return game.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct) {
            var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id, ct);
            if (game == null)
                throw new KeyNotFoundException();
            context.Games.Remove(game);
            await context.SaveChangesAsync(ct);
        }

        public async Task<Game?> GetByIdAsync(Guid id, CancellationToken ct) {
            return await context.Games
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(g => g.Id == id, ct);
        }

        public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken ct) {
            return await context.Games.ToListAsync(ct);
        }
    }

}
