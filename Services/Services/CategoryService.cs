using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

internal class CategoryService(IRestClient<Category> CategoryRepository) : IRepositoryService<Category>
{
    public void Add(Category objeto)
    {
        CategoryRepository.Add(objeto);
    }
    public void Delete(Category item)
    {
        CategoryRepository.Delete(item);
    }
    public Category? Get(int id)
    {
        return CategoryRepository.Get(id);
    }
    public Task<List<Category>> GetAll()
    {
        return CategoryRepository.GetAll();
    }
    public void Update(Category objeto)
    {
        CategoryRepository.Update(objeto);
    }
}