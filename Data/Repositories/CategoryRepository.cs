using Microsoft.EntityFrameworkCore;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

internal class CategoryRepository(AppDbContext context) : IRepository<Category>
{
    private readonly AppDbContext _context = context;
    public List<Category> GetAll() => _context.Categories.ToList();
    public void Add(Category category) => _context.Add(category);
    public void Delete(Category category) { _context.Categories.Remove(category); _context.SaveChanges(); }
    public Category? Get(int id) => _context.Categories.Find(id);
    public void Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
