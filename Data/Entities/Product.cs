namespace P05_01_DI_Productos_TAPIADOR_rodrigo.Data.Entities;

internal class Product
{
    public string Nombre;
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public int IdCategoria { get; set; }
    public int Id { get; set; }


    public Product() { }
    public Product(string nombre, string descripcion, double precio, int categoria)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        IdCategoria = categoria;
    }
}
