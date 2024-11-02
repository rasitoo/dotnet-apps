using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.dataclases;
using System.Text;
using System.Xml.Serialization;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.repositories;

internal class ProductoRepository : IRepository<Producto>
{
    private string filePath = "Producto.xml";
    public List<Producto> Productos { get; set; }
    public ProductoRepository()
    {
        Productos = new();
        CargarDesdeXml();
    }

    public void Anadir(Producto producto)
    {
        if (Productos.Count != 0)
            producto.Id = Productos.Last().Id + 1;
        else
            producto.Id = 0;
        Productos.Add(producto);

    }

    public void Borrar(int pos)
    {
        if (pos != -1)
        {
            Productos.RemoveAt(pos);
        }
    }
    public Producto Consultar(int id)
    {
        foreach (var producto in Productos)
        {
            if (producto.Id == id)
            {
                return producto;
            }
        }

        return null;
    }
    public void Modificar(int pos, Producto producto)
    {
        if (pos != -1)
        {
            int ident = Productos[pos].Id;
            producto.Id = ident;
            Productos[pos] = producto;
        }
    }
    public void GuardarEnXml()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, Productos);
        }
    }

    public void CargarDesdeXml()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            Productos = (List<Producto>)serializer.Deserialize(reader);
        }
    }

}
