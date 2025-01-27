using Microsoft.EntityFrameworkCore;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

internal class ProductRepository(AppDbContext context) : IRepository<Product>
{
    private readonly AppDbContext _context = context;
    public List<Product> GetAll() => [.. _context.Products];
    public void Add(Product product) => _context.Add(product);
    public void Delete(Product product) { _context.Products.Remove(product).State = EntityState.Deleted; _context.SaveChanges(); }
    public Product? Get(int id) => _context.Products.Find(id);
    public void Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
