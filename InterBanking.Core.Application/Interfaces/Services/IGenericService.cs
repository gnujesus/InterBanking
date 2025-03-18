namespace InterBanking.Core.Application.Interfaces.Services;

public interface IGenericService<Entity> where Entity : class
{
    Task<Entity> Add(Entity entity);

    Task<Entity> GetById(int id);
    Task<List<Entity>> GetAll(int id);

    Task<Entity> Update(Entity entity);

    Task Delete(Entity entity);
}