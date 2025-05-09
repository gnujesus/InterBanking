namespace InterBanking.Core.Application.Interfaces.Services;

public interface IGenericService<Entity, ViewModel, SaveViewModel> 
    where Entity : class
    where ViewModel: class
    where SaveViewModel : class
{
    Task<SaveViewModel> Add(SaveViewModel svm);

    Task<ViewModel> GetById(int id);
    Task<List<ViewModel>> GetAll();

    Task<SaveViewModel> Update(SaveViewModel svm, int id);

    Task Delete(ViewModel vm);
}