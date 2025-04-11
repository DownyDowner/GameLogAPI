namespace GameLogAPI.src.Repositories {
    public interface IRepository<T> where T : class {
        Task<Guid> AddAsync(T entity, CancellationToken ct);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
        Task<T?> GetByIdAsync(Guid id, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}
