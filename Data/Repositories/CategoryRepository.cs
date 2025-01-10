using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.IO;
using System.Xml.Serialization;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

internal class CategoryRepository : IRepository<Category>
{
    private string filePath = "./Category.xml";
    public List<Category> Categories { get; set; }
    public CategoryRepository()
    {
        Categories = new();
    }
    public void Add(Category Category)
    {

        if (Categories.Count != 0)
            Category.Id = Categories.Last().Id + 1;
        else
            Category.Id = 0;
        Categories.Add(Category);
    }
    public void Delete(int pos)
    {
        if (pos != -1)
        {
            Categories.RemoveAt(pos);
        }
    }
    public Category Get(int id)
    {
        if (id == -1)
        {
            return new Category("null");
        }
        else
        {
            foreach (var Category in Categories)
            {
                if (Category.Id == id)
                {
                    return Category;
                }
            }
        }

        return null;
    }
    public void Update(int pos, Category Category)
    {
        if (pos != -1)
        {
            int ident = Categories[pos].Id;
            Category.Id = ident;
            Categories[pos] = Category;
        }
    }


    public List<Category> GetAll()
    {
        throw new NotImplementedException();
    }
}
