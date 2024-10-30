using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.dataclases;
using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.repositories;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;

internal class CounterModel : IModel
{
    internal CategoriaRepository CategoriaRepository { get; set; }
    internal ProductoRepository ProductoRepository { get; set; }

    public CounterModel()
    {
        CategoriaRepository = new();
        ProductoRepository = new();
    }

    public void AnadirProducto(Producto product)
    {
        throw new NotImplementedException();
    }

    public void AnadirCategoria(Categoria categoria)
    {
        throw new NotImplementedException();
    }

    public void ModificarProducto(int id, Producto product)
    {
        throw new NotImplementedException();
    }

    public void ModificarCategoria(int id, Categoria categoria)
    {
        throw new NotImplementedException();
    }

    public Producto ConsultarProducto(int id)
    {
        throw new NotImplementedException();
    }

    public Categoria ConsultarCategoria(int id)
    {
        throw new NotImplementedException();
    }

    public Producto ConsultarNombreProducto(string nombre)
    {
        throw new NotImplementedException();
    }

    public Categoria ConsultarNombreCategoria(string nombre)
    {
        throw new NotImplementedException();
    }

    public void BorrarProducto(int id)
    {
        throw new NotImplementedException();
    }

    public void BorrarCategoria(int id)
    {
        throw new NotImplementedException();
    }

    public int BuscarPosicionProducto(int id)
    {
        throw new NotImplementedException();
    }

    public int BuscarPosicionCategoria(int id)
    {
        throw new NotImplementedException();
    }

    public Producto BuscarProductoDesdePosicion(int pos)
    {
        throw new NotImplementedException();
    }

    public Categoria BuscarCategoriaDesdePosicion(int pos)
    {
        throw new NotImplementedException();
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
}
