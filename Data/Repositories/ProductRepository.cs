using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.IO;
using System.Xml.Serialization;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

internal class ProductRepository : IRepository<Product>
{
    private List<Product> _products;
    public ProductRepository()
    {
        _products = new();
        AddProducts();

    }

    public void AddProducts()
    {
        // Verduras
        _products.Add(new Product("Tomate", "Tomate fresco", 1.5, 1));
        _products.Add(new Product("Lechuga", "Lechuga verde", 1.0, 1));
        _products.Add(new Product("Zanahoria", "Zanahoria orgánica", 0.8, 1));
        _products.Add(new Product("Pepino", "Pepino fresco", 1.2, 1));
        _products.Add(new Product("Espinaca", "Espinaca fresca", 1.3, 1));

        // Carnes
        _products.Add(new Product("Pollo", "Pollo fresco", 5.0, 2));
        _products.Add(new Product("Ternera", "Ternera de primera", 10.0, 2));
        _products.Add(new Product("Cerdo", "Cerdo fresco", 7.0, 2));
        _products.Add(new Product("Cordero", "Cordero fresco", 12.0, 2));
        _products.Add(new Product("Pavo", "Pavo fresco", 8.0, 2));

        // Herramientas
        _products.Add(new Product("Martillo", "Martillo de acero", 15.0, 3));
        _products.Add(new Product("Destornillador", "Destornillador de estrella", 5.0, 3));
        _products.Add(new Product("Llave inglesa", "Llave inglesa ajustable", 20.0, 3));
        _products.Add(new Product("Taladro", "Taladro eléctrico", 50.0, 3));
        _products.Add(new Product("Sierra", "Sierra manual", 25.0, 3));

        // Menaje
        _products.Add(new Product("Plato", "Plato de cerámica", 3.0, 4));
        _products.Add(new Product("Vaso", "Vaso de cristal", 2.0, 4));
        _products.Add(new Product("Cuchara", "Cuchara de acero inoxidable", 1.5, 4));
        _products.Add(new Product("Tenedor", "Tenedor de acero inoxidable", 1.5, 4));
        _products.Add(new Product("Cuchillo", "Cuchillo de cocina", 2.5, 4));
    }



    public void Add(Product Product)
    {
        if (_products.Count != 0)
            Product.Id = _products.Last().Id + 1;
        else
            Product.Id = 0;
        _products.Add(Product);

    }

    public void Delete(int pos)
    {
        if (pos != -1)
        {
            _products.RemoveAt(pos);
        }
    }
    public Product Get(int id)
    {
        foreach (var Product in _products)
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
            int ident = _products[pos].Id;
            Product.Id = ident;
            _products[pos] = Product;
        }
    }

    public List<Product> GetAll()
    {
        return _products.ToList();
    }
}
