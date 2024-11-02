using System.Xml.Serialization;
namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.dataclases;

public class Producto
{
    public string Nombre;
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public int IdCategoria { get; set; }
    public int Id { get; set; }


    public Producto() { }
    public Producto(string nombre, string descripcion, double precio, int categoria)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        IdCategoria = categoria;
    }

}
