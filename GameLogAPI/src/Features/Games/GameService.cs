using GameLogAPI.src.Data;
using GameLogAPI.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameLogAPI.src.Features.Games {
    public class GameService(GameDbContext context) {
        internal async Task<IEnumerable<Game>> GetGames(CancellationToken ct) {
            return await context
                .Games
                .ToArrayAsync(ct);
        }
    }
}
