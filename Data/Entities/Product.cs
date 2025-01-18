namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

internal class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public int Id { get; set; }


    public Product(string nombre, string descripcion, double precio, int categoria)
    {
        Name = nombre;
        Description = descripcion;
        Price = precio;
        CategoryId = categoria;
    }
}
