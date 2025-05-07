﻿using GameLogAPI.src.Data;
using GameLogAPI.src.Entities;
using GameLogAPI.src.Exceptions;
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
                throw new ServiceException($"Game with ID {id} was not found.", StatusCodes.Status404NotFound);

            context.Games.Remove(game);
            await context.SaveChangesAsync(ct);
        }

        public async Task<Game> GetByIdAsync(Guid id, CancellationToken ct) {
            var game = await context.Games
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(g => g.Id == id, ct);

            if (game == null)
                throw new ServiceException($"Game with ID {id} was not found.", StatusCodes.Status404NotFound);

            return game;
        }

        public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken ct) {
            return await context.Games
                .Include(g => g.Platform)
                .ToListAsync(ct);
        }

        public async Task UpdateGameStatusAsync(Guid id, GameStatus status, CancellationToken ct) {
            var game = await context.Games
                .FirstOrDefaultAsync(g => g.Id == id, ct);

            if (game == null)
                throw new ServiceException($"Cannot update status: game with ID {id} was not found.", StatusCodes.Status404NotFound);

            game.Status = status;
            if (status == GameStatus.Playing)
                game.StartedOn = DateTime.Now;

            await context.SaveChangesAsync(ct);
        }

        public async Task UpdateGameStatusWithReviewAsync(Guid id, GameStatus status, int? rating, string? review, CancellationToken ct) {
            var game = await context.Games
                .FirstOrDefaultAsync(g => g.Id == id, ct);

            if (game == null)
                throw new ServiceException($"Cannot update status and review: game with ID {id} was not found.", StatusCodes.Status404NotFound);

            game.Status = status;
            game.Rating = rating;
            game.Review = review;

            if (status == GameStatus.Completed)
                game.CompletedOn = DateTime.Now;

            await context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<Game>> GetGamesCompleted(CancellationToken ct) {
            return await context.Games
                .Where(g => g.Status == GameStatus.Completed)
                .Include(g => g.Platform)
                .OrderByDescending(g => g.CompletedOn)
                .ThenBy(g => g.Title)
                .ToListAsync(ct);
        }

        public async Task UpdateAsync(Game entity, CancellationToken ct) {
            context.Update(entity);
            await context.SaveChangesAsync(ct);
        }
    }
}
