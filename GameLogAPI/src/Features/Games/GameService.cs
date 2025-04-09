using GameLogAPI.src.Data;
using GameLogAPI.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameLogAPI.src.Features.Games {
    public class GameService(GameDbContext context) {
        internal async Task<Guid> AddGame(AddGameRequest req, CancellationToken ct) {
            var game = new Game { Title= req.Title, Platform = req.Platform };
            await context.Games.AddAsync(game, ct);
            await context.SaveChangesAsync();

            return game.Id;
        }

        internal async Task<Game?> GetGame(Guid id) {
            return await context
                .Games
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        internal async Task<IEnumerable<Game>> GetGames(CancellationToken ct) {
            return await context
                .Games
                .ToArrayAsync(ct);
        }
    }
}
