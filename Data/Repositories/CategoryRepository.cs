using Microsoft.EntityFrameworkCore;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

internal class CategoryRepository(AppDbContext context) : IRepository<Category>
{
    public List<Category> GetAll() => context.Categories.ToList();
    public void Add(Category category) => context.Add(category);
    public void Delete(Category category) { context.Categories.Remove(category).State = EntityState.Deleted; context.SaveChanges(); }
    public Category? Get(int id) => context.Categories.Find(id);
    public void Update(Category category)
    {
        context.Entry(category).State = EntityState.Modified;
        context.SaveChanges();
    }
}
