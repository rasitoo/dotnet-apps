using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

internal class ProductService(IRestClient<Product> ProductRepository) : IRepositoryService<Product>
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
    public Task<List<Product>> GetAll()
    {
        return ProductRepository.GetAll();
    }
    public void Update(Product objeto)
    {
        ProductRepository.Update(objeto);
    }
}