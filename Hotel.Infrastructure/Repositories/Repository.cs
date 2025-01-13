using Hotel.Domain.Repositories;
using Hotel.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Repositories;

public class Repository<TData>(ApplicationDbContext context) : IRepository<TData>
    where TData : class
{
    public async Task<IEnumerable<TData>> GetAllAsync()
        => await context.Set<TData>().ToListAsync();

    public async Task<TData?> GetByIdAsync(Guid id)
        => await context.Set<TData>().FindAsync(id);

    public async Task<TData> AddAsync(TData data)
    {
        await context.Set<TData>().AddAsync(data);
        await context.SaveChangesAsync();

        return data;
    }

    public async Task UpdateAsync(Guid id, TData data)
    {
        var entry = context.Entry(data);

        if (entry.State is EntityState.Detached)
            context.Set<TData>().Update(data);

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        if (entity is not null)
        {
            context.Set<TData>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}