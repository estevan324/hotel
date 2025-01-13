namespace Hotel.Domain.Repositories;

public interface IRepository<TData> where TData : class
{
    Task<IEnumerable<TData>> GetAllAsync();
    Task<TData?> GetByIdAsync(Guid id);
    Task<TData> AddAsync(TData data);
    Task UpdateAsync(Guid id, TData data);
    Task DeleteAsync(Guid id);
}