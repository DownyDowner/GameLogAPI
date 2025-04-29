using GameLogAPI.src.Entities;
using GameLogAPI.src.Features.Games;
using GameLogAPI.src.Repositories;

namespace GameLogAPI.src.Services {
    public class GameService(IGameRepository repository) {
        internal async Task<Guid> AddGame(AddGameRequest req, CancellationToken ct) {
            var game = new Game { Title= req.Title, IdPlatform = req.IdPlatform, ReleaseDate = req.ReleaseDate };
            return await repository.AddAsync(game, ct);
        }

        internal async Task DeleteGame(Guid id, CancellationToken ct) {
            await repository.DeleteAsync(id, ct);
        }

        internal async Task<Game> GetGame(Guid id, CancellationToken ct) {
            return await repository.GetByIdAsync(id, ct);
        }

        internal async Task<IEnumerable<Game>> GetGames(CancellationToken ct) {
            return await repository.GetAllAsync(ct);
        }

        internal async Task<IEnumerable<Game>> GetGamesCompleted(CancellationToken ct) {
            return await repository.GetGamesCompleted(ct);
        }

        internal async Task UpdateGameStatus(Guid id, GameStatus status, CancellationToken ct) {
            await repository.UpdateGameStatusAsync(id, status, ct);
        }

        internal async Task UpdateGameStatusWithReview(Guid id, GameStatus status, int? rating, string? review, CancellationToken ct) {
            await repository.UpdateGameStatusWithReviewAsync(id, status, rating, review, ct);
        }
    }
}
