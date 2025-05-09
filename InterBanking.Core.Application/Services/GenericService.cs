using AutoMapper;
using InterBanking.Core.Application.Interfaces.Repositories;
using InterBanking.Core.Application.Interfaces.Services;

namespace InterBanking.Core.Application.Services;

public class GenericService<Entity, ViewModel, SaveViewModel> : IGenericService<Entity, ViewModel, SaveViewModel> 
    where Entity: class
    where ViewModel : class 
    where SaveViewModel : class
{
    // Implement automapper

    private readonly IGenericRepository<Entity> _repository;
    private readonly IMapper _mapper;

    public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SaveViewModel> Add(SaveViewModel svm)
    {
        Entity mappedEntity =  _mapper.Map<Entity>(svm);
        return _mapper.Map<SaveViewModel>(await _repository.AddAsync(mappedEntity));
    }

    public async Task<ViewModel> GetById(int id)
    {
        return _mapper.Map<ViewModel>(await _repository.GetByIdAsync(id));
    }

    public async Task<List<ViewModel>> GetAll()
    {
        return _mapper.Map<List<ViewModel>>(await _repository.GetAllAsync());
    }

    public async Task<SaveViewModel> Update(SaveViewModel vm, int id)
    {
        Entity entity = _mapper.Map<Entity>(vm);
        return _mapper.Map<SaveViewModel>(await _repository.UpdateAsync(entity, id));
        
    }

    public Task Delete(ViewModel vm)
    {
        Entity entity = _mapper.Map<Entity>(vm);
        return _repository.DeleteAsync(entity);
    }
}