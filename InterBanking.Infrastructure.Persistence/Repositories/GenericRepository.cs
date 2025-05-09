using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InterBanking.Infrastructure.Persistence.Repositories;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
{
    private readonly ApplicationContext _dbContext;

    public GenericRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Entity> AddAsync(Entity entity)
    {
        // TODO: Check it works
        await _dbContext.Set<Entity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Entity> GetByIdAsync(int id)
    {
        // TODO: exception handling: possibly null reference
        return await _dbContext.Set<Entity>().FindAsync(id);
    }

    public async Task<List<Entity>> GetAllAsync()
    {
        return await _dbContext.Set<Entity>().ToListAsync();
    }

    public async Task<Entity> UpdateAsync(Entity entity, int id)
    {
        // TODO: Check it works
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Entity entity)
    {
        _dbContext.Set<Entity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}