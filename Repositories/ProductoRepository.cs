using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Repositories;

internal class ProductoRepository : IRepository<Producto>
{

    public List<Producto> Productos { get; set; }
    public ProductoRepository()
    {
        Productos = new();
        Anadir(new Producto("Prueba1", "prueba1", 0.0, new Categoria("Prueba1")));
        Anadir(new Producto("Prueba2", "prueba2", 0.0, new Categoria("Prueba2")));
        Anadir(new Producto("Prueba3", "prueba3", 0.0, new Categoria("Prueba3")));
        Anadir(new Producto("Prueba4", "prueba4", 0.0, new Categoria("Prueba4")));
        Anadir(new Producto("Prueba5", "prueba5", 0.0, new Categoria("Prueba5")));
        Anadir(new Producto("Prueba6", "prueba6", 0.0, new Categoria("Prueba6")));
        Anadir(new Producto("Prueba7", "prueba7", 0.0, new Categoria("Prueba7")));
        Anadir(new Producto("Prueba8", "prueba8", 0.0, new Categoria("Prueba8")));
        Anadir(new Producto("Prueba9", "prueba9", 0.0, new Categoria("Prueba9")));
        Anadir(new Producto("Prueba10", "prueba10", 0.0, new Categoria("Prueba10")));
        Anadir(new Producto("Prueba11", "prueba11", 0.0, new Categoria("Prueba11")));
        Anadir(new Producto("Prueba12", "prueba12", 0.0, new Categoria("Prueba12")));
        Anadir(new Producto("Prueba13", "prueba13", 0.0, new Categoria("Prueba13")));
        Anadir(new Producto("Prueba14", "prueba14", 0.0, new Categoria("Prueba14")));
        Anadir(new Producto("Prueba15", "prueba15", 0.0, new Categoria("Prueba15")));
        Anadir(new Producto("Prueba16", "prueba16", 0.0, new Categoria("Prueba16")));
        Anadir(new Producto("Prueba17", "prueba17", 0.0, new Categoria("Prueba17")));
        Anadir(new Producto("Prueba18", "prueba18", 0.0, new Categoria("Prueba18")));
        Anadir(new Producto("Prueba19", "prueba19", 0.0, new Categoria("Prueba19")));
        Anadir(new Producto("Prueba20", "prueba20", 0.0, new Categoria("Prueba20")));
    }

    public void Anadir(Producto producto)
    {
        producto.Id = Productos.Count;
        Productos.Add(producto);

    }

    public void Borrar(string nombre)
    {
        int posicion = buscarPosicion(nombre);
        if (posicion != -1)
        {
            Productos.RemoveAt(posicion);
        }
    }

    private int buscarPosicion(string nombre)
    {
        return Productos.FindIndex(c => c.Nombre.Equals(nombre));
    }

    public Producto Consultar(string nombre)
    {
        foreach (var producto in Productos)
        {
            if (producto.Nombre.Equals(nombre))
            {
                return producto;
            }
        }

        return null;
    }

    public void Modificar(string nombre, Producto producto)
    {
        int posicion = buscarPosicion(nombre);
        if (posicion != -1)
        {
            Productos[posicion] = producto;
        }
    }
}
