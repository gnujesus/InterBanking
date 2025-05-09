﻿namespace InterBanking.Core.Application.Interfaces.Repositories;

public interface IGenericRepository<Entity> where Entity: class
{
    Task<Entity> AddAsync(Entity entity);
    
    Task<Entity> GetByIdAsync(int id);
    Task<List<Entity>> GetAllAsync();
    
    Task<Entity> UpdateAsync(Entity entity, int id);
    
    Task DeleteAsync(Entity entity);
}