using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

internal class ProductService : IRepositoryService<Product>
{
    internal ProductRepository ProductRepository { get; set; }
    public void Add(Product objeto)
    {
        ProductRepository.Add(objeto);
    }

    public void Delete(int id)
    {
        ProductRepository.Delete(id);
    }

    public Product Get(int id)
    {
        return ProductRepository.Get(id);
    }

    public List<Product> GetAll()
    {
        return ProductRepository.GetAll();
    }

    public void Update(int pos, Product objeto)
    {
        ProductRepository.Update(pos, objeto);
    }
}
