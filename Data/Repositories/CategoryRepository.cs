using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.IO;
using System.Xml.Serialization;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

internal class CategoryRepository : IRepository<Category>
{
    private string filePath = "./Category.xml";
    private List<Category> _categories;
    public CategoryRepository()
    {
        _categories = new();
        _categories.Add( new("Verduras"));
        _categories.Add(new("Carnes"));
        _categories.Add(new("Herramientas"));
        _categories.Add(new("Menaje"));
    }
    public void Add(Category Category)
    {

        if (_categories.Count != 0)
            Category.Id = _categories.Last().Id + 1;
        else
            Category.Id = 0;
        _categories.Add(Category);
    }
    public void Delete(int pos)
    {
        if (pos != -1)
        {
            _categories.RemoveAt(pos);
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
            foreach (var Category in _categories)
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
            int ident = _categories[pos].Id;
            Category.Id = ident;
            _categories[pos] = Category;
        }
    }


    public List<Category> GetAll()
    {
        return _categories.ToList();
    }
}
