using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.IO;
using System.Xml.Serialization;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

internal class ProductRepository : IRepository<Product>
{
    private string filePath = "Product.xml";
    public List<Product> Products { get; set; }
    public ProductRepository()
    {
        Products = new();
    }

    public void Add(Product Product)
    {
        if (Products.Count != 0)
            Product.Id = Products.Last().Id + 1;
        else
            Product.Id = 0;
        Products.Add(Product);

    }

    public void Delete(int pos)
    {
        if (pos != -1)
        {
            Products.RemoveAt(pos);
        }
    }
    public Product Get(int id)
    {
        foreach (var Product in Products)
        {
            if (Product.Id == id)
            {
                return Product;
            }
        }

        return null;
    }
    public void Update(int pos, Product Product)
    {
        if (pos != -1)
        {
            int ident = Products[pos].Id;
            Product.Id = ident;
            Products[pos] = Product;
        }
    }

    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }
}
