using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Core.Application.Interfaces.Services;

namespace InterBanking.Core.Application.Services;

public class GenericService<Entity> : IGenericService<Entity> where Entity : class 
{
    private readonly IGenericRepository<Entity> _repository;

    public GenericService(IGenericRepository<Entity> repository)
    {
        _repository = repository;
    }


    public async Task<Entity> Add(Entity entity)
    {
        return await _repository.AddAsync(entity);
    }

    public async Task<Entity> GetById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<List<Entity>> GetAll(int id)
    {
        return await _repository.GetAllAsync(id);
    }

    public Task<Entity> Update(Entity entity)
    {
        return _repository.UpdateAsync(entity);
    }

    public Task Delete(Entity entity)
    {
        return _repository.DeleteAsync(entity);
    }
}