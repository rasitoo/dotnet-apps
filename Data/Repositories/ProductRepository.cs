using Microsoft.EntityFrameworkCore;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

internal class ProductRepository(AppDbContext context) : IRepository<Product>
{
    public List<Product> GetAll() => context.Products.ToList();
    public void Add(Product product) {context.Add(product).State = EntityState.Added; context.SaveChanges();}
    public void Delete(Product product) { context.Products.Remove(product).State = EntityState.Deleted; context.SaveChanges(); }
    public Product? Get(int id) => context.Products.Find(id);
    public void Update(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
        context.SaveChanges();
    }
}
