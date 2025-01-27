using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

internal class ProductService(IRepository<Product> ProductRepository) : IRepositoryService<Product>
{
    public void Add(Product objeto)
    {
        ProductRepository.Add(objeto);
    }

    public void Delete(Product item)
    {
        ProductRepository.Delete(item);
    }

    public Product? Get(int id)
    {
        return ProductRepository.Get(id);
    }

    public List<Product> GetAll()
    {
        return ProductRepository.GetAll();
    }

    public void Update(Product objeto)
    {
        ProductRepository.Update(objeto);
    }
}
