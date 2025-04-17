using GameLogAPI.src.Entities;

namespace GameLogAPI.src.Repositories {
    public interface IGameRepository : IRepository<Game> {
        public Task UpdateGameStatusAsync(Guid id, GameStatus status, CancellationToken ct);
    }
}
