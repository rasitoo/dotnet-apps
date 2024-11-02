using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.dataclases;
using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.repositories;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;

internal class Model : IModel
{
    internal CategoriaRepository CategoriaRepository { get; set; }
    internal ProductoRepository ProductoRepository { get; set; }

    public Model()
    {
        CategoriaRepository = new();
        ProductoRepository = new();
    }

    public void AnadirProducto(Producto product)
    {
        ProductoRepository.Anadir(product);
    }

    public void AnadirCategoria(Categoria categoria)
    {
        CategoriaRepository.Anadir(categoria);
    }

    public void ModificarProducto(int id, Producto product)
    {
        ProductoRepository.Modificar(BuscarPosicionProducto(id), product);
    }

    public void ModificarCategoria(int id, Categoria categoria)
    {
        CategoriaRepository.Modificar(BuscarPosicionCategoria(id), categoria);
    }

    public Producto ConsultarProducto(int id)
    {
        return ProductoRepository.Consultar(id);
    }

    public Categoria ConsultarCategoria(int id)
    {
        return CategoriaRepository.Consultar(id);
    }

    public Producto ConsultarNombreProducto(string nombre)
    {
        foreach (var producto in ProductoRepository.Productos)
        {
            if (producto.Nombre.Equals(nombre))
            {
                return producto;
            }
        }

        return null;
    }

    public Categoria ConsultarNombreCategoria(string nombre)
    {
        foreach (var categoria in CategoriaRepository.Categorias)
        {
            if (categoria.Nombre.Equals(nombre))
            {
                return categoria;
            }
        }

        return null;
    }

    public void BorrarProducto(int id)
    {
        ProductoRepository.Borrar(id);
    }

    public void BorrarCategoria(int id)
    {
        CategoriaRepository.Borrar(id);
    }

    public int BuscarPosicionProducto(int id)
    {
        return ProductoRepository.Productos.FindIndex(c => c.Id == id);
    }

    public int BuscarPosicionCategoria(int id)
    {
        return CategoriaRepository.Categorias.FindIndex(c => c.Id == id);
    }

    public Producto BuscarProductoDesdePosicion(int pos)
    {
        if (pos < 0 || pos >= ProductoRepository.Productos.Count)
        {
            return new("","",0,-1);
        }
        return ProductoRepository.Productos.ElementAt(pos);
    }

    public Categoria BuscarCategoriaDesdePosicion(int pos)
    {
        if (CategoriaRepository.Categorias.Count > 0)
            return CategoriaRepository.Categorias.ElementAt(pos);
        return new Categoria("null");
    }
    public void ActualizarCategoriaDeProductos(int ctid)
    {
        for (int i = 0; i < ProductoRepository.Productos.Count; i++)
        {
            Producto pr = ProductoRepository.Productos[i];
            if (pr.IdCategoria == ctid)
            {
                ProductoRepository.Modificar(pr.Id, new Producto(pr.Nombre, pr.Descripcion, pr.Precio, -1));
            }
        }
    }

    public bool ExisteCategoria(string nombre)
    {
        if ((CategoriaRepository.Categorias.Exists(c => c.Nombre.Equals(nombre))))
            return true;
        return false;
    }
    public List<String> listarProductosPorCategoria(Categoria categoria)
    {
        List<String> lista = new();
        foreach (var producto in ProductoRepository.Productos)
        {
            if (producto.IdCategoria == categoria.Id)
            {
                lista.Add(producto.Nombre);
            }
        }
        return lista;
    }
    public List<String> ListarProductos()
    {
        List<String> lista = new();
        foreach (var producto in ProductoRepository.Productos)
        {
            lista.Add(producto.Nombre);
        }
        return lista;
    }
    public List<String> ListarCategorias()
    {
        List<String> lista = new();
        foreach (var categoria in CategoriaRepository.Categorias)
        {
            lista.Add(categoria.Nombre);
        }
        return lista;
    }

    public void GuardarEnXML()
    {
        ProductoRepository.GuardarEnXml();
        CategoriaRepository.GuardarEnXml();
    }
}
