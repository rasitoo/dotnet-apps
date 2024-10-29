using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;
using P03_02_DI_Contactos_TAPIADOR_rodrigo.Repositories;
using P03_02_DI_Contactos_TAPIADOR_rodrigo.Views;
using System.Windows.Forms;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Presenters;

internal class MainPresenter : IPresenter
{
    private IView _view;
    private MainRepository repository;

    public MainPresenter(IView view, MainRepository repository)
    {
        this._view = view;
        this.repository = repository;
        view.cambiarLista(ListarProductos());
        _view.ListBoxItemSelected += OnListBoxItemSelected;
        _view.productoAnadir_Click += OnProductoAnadir_Click;
        _view.buttonEliminar_Click += OnButtonEliminar_Click;
        _view.buttonModificar_Click += OnButtonModificar_Click;

    }
    private void OnListBoxItemSelected(object sender, EventArgs e)
    {
        string selectedItem = _view.SelectedItem;
        Producto pr = repository.ProductoRepository1.Consultar(selectedItem);
        Mostrar(pr);
    }

    private void Mostrar(Producto pr)
    {
        if (!(pr is null))
        {
            _view.DisplayId = pr.Id.ToString();
            _view.DisplayNombre = pr.Nombre;
            _view.DisplayDescripcion = pr.Descripcion;
            _view.DisplayPrecio = pr.Precio.ToString();
            _view.DisplayPertenencia = repository.CategoriaRepository.Consultar(pr.IdCategoria).Nombre;
        }
    }

    private void OnProductoAnadir_Click(object sender, EventArgs e)
    {
        Producto pr = new Producto("", "", 0.0, new Categoria(""));
        repository.ProductoRepository1.Anadir(pr);
        _view.cambiarLista(ListarProductos());
        Mostrar(pr);
    }
    private void OnButtonEliminar_Click(object sender, EventArgs e)
    {
        repository.ProductoRepository1.Borrar(_view.SelectedItem);
        _view.cambiarLista(ListarProductos());

    }
    private void OnButtonModificar_Click(object sender, EventArgs e)
    {
        repository.ProductoRepository1.Modificar(_view.DisplayNombre, new Producto(_view.DisplayNombre, _view.DisplayDescripcion, Double.Parse(_view.DisplayPrecio), new Categoria("x")));
    }


    //private void ListarOrdenado()
    //{

    //    List<Categoria> categorias = repository.CategoriaRepository.Categorias;
    //    List<Producto> productos = repository.ProductoRepository1.Productos;
    //    foreach (var categoria in categorias)
    //    {
    //        vista.ActualizaVista(categoria.ToString());
    //        for (int i = 0; i < productos.Count; i++)
    //        {
    //            if (productos[i].Categoria.Nombre.Equals(categoria.Nombre))
    //            {
    //                vista.ActualizaVista("\t" + productos[i].ToString());
    //                productos.RemoveAt(i);
    //            }
    //        }
    //    }
    //}


    //private void EliminarCategoria()
    //{

    //    vista.ActualizaVista("Introduce el nombre de la categoria: ");
    //    string strCategoria = Console.ReadLine();
    //    if (!(modelo.Categoria.Consultar(strCategoria) is null))
    //    {
    //        modelo.Categoria.Borrar(strCategoria);
    //        vista.ActualizaVista($"Categoria {strCategoria} eliminado");
    //    }
    //    else
    //    {
    //        vista.ActualizaVista("La categoria introducida no existe");
    //    }
    //}

    //private void EliminarProducto()
    //{
    //    vista.ActualizaVista("Introduce el nombre del producto: ");
    //    string nombre = Console.ReadLine();
    //    if (!(modelo.Producto.Consultar(nombre) is null))
    //    {
    //        modelo.Producto.Borrar(nombre);
    //        vista.ActualizaVista($"Producto {nombre} eliminado");

    //    }
    //    else
    //    {
    //        vista.ActualizaVista("El producto no existe");
    //    }
    //}


    //private void ModificarCategoria()
    //{
    //    vista.ActualizaVista("Introduce el nombre de la categoria que quieras modificar: ");
    //    string strCategoria = Console.ReadLine();
    //    vista.ActualizaVista("Introduce el nuevo nombre de la categoria: ");
    //    string strCategorianueva = Console.ReadLine();
    //    if (!(modelo.Categoria.Consultar(strCategoria) is null))
    //    {
    //        modelo.Categoria.Modificar(strCategoria, new Categoria(strCategorianueva));
    //        vista.ActualizaVista($"Categoria {strCategoria} modificada a {strCategorianueva}");
    //        List<Producto> lista = modelo.Producto.Productos;
    //        for (int i = 0; i < lista.Count; i++)
    //        {
    //            if (lista[i].Categoria.Nombre.Equals(strCategoria))
    //            {
    //                modelo.Producto.Modificar(lista[i].Nombre, new Producto(lista[i].Nombre, lista[i].Descripcion, lista[i].Precio, (modelo.Categoria.Consultar(strCategorianueva))));
    //            }

    //        }
    //        vista.ActualizaVista($"Productos de categoria {strCategoria} modificados a {strCategorianueva}");

    //    }
    //    else
    //    {
    //        vista.ActualizaVista("La categoria introducida no existe");
    //    }
    //}

    //private void ModificarProducto()
    //{
    //    vista.ActualizaVista("Introduce el nombre del producto que quieras modificar: ");
    //    string strProducto = Console.ReadLine();
    //    Producto anteriorProd = modelo.Producto.Consultar(strProducto);
    //    if (!string.IsNullOrEmpty(strProducto))
    //    {


    //        vista.ActualizaVista(
    //            "Para mantener cualquiera de los datos anteriores deja el espacio en blanco en el atributo deseado ");
    //        vista.ActualizaVista($"Introduce el nuevo nombre de la categoria (antes {anteriorProd.Nombre}): ");
    //        string strProductoNuevo = Console.ReadLine();
    //        if (string.IsNullOrEmpty(strProductoNuevo))
    //        {
    //            strProductoNuevo = anteriorProd.Nombre;
    //        }

    //        if (anteriorProd.Nombre.Equals(strProductoNuevo) || (modelo.Producto.Consultar(strProductoNuevo) is null))
    //        {

    //            vista.ActualizaVista(
    //                $"Introduce una breve descripción del producto (antes {anteriorProd.Descripcion}): ");
    //            string desc = Console.ReadLine();
    //            if (string.IsNullOrEmpty(desc))
    //            {
    //                desc = anteriorProd.Descripcion;
    //            }

    //            vista.ActualizaVista($"Introduce el precio del producto (antes {anteriorProd.Precio}): ");
    //            string precioStr = Console.ReadLine();
    //            double prec = 0;
    //            if (string.IsNullOrEmpty(precioStr))
    //            {
    //                precioStr = null;
    //                prec = anteriorProd.Precio;
    //            }

    //            if (precioStr is null || double.TryParse(precioStr, out prec))
    //            {
    //                vista.ActualizaVista($"Introduce la categoria del producto (antes {anteriorProd.Categoria}): ");
    //                string strCategoria = Console.ReadLine();
    //                Categoria categoria = null;

    //                if (string.IsNullOrEmpty(strCategoria))
    //                {
    //                    categoria = anteriorProd.Categoria;
    //                }
    //                else if (!(modelo.Categoria.Consultar(strCategoria) is null))
    //                {
    //                    categoria = modelo.Categoria.Consultar(strCategoria);
    //                }
    //                else
    //                {
    //                    vista.ActualizaVista("La categoria introducida no existe");
    //                }

    //                if (categoria != null)
    //                {
    //                    modelo.Producto.Modificar(strProducto, new Producto(strProductoNuevo, desc, prec, categoria));
    //                    vista.ActualizaVista("Producto modificado satisfactoriamente");

    //                }
    //            }
    //            else
    //            {
    //                vista.ActualizaVista("El precio introducido no es válido.");
    //            }
    //        }
    //        else
    //        {
    //            vista.ActualizaVista("El producto ya existe");
    //        }
    //    }
    //    else
    //    {
    //        vista.ActualizaVista("Nombre no valido");
    //    }
    //}

    //private void ConsultarCategoria()
    //{
    //    vista.ActualizaVista("Introduce el nombre de la categoria (Dejar en blanco para todas las categorias): ");
    //    string nombre = Console.ReadLine(); //Deberia comprobar si la categoria ya existe

    //    if (string.IsNullOrEmpty(nombre))
    //    {
    //        List<Categoria> categorias = modelo.Categoria.Categorias;
    //        foreach (var categoria in categorias)
    //        {
    //            vista.ActualizaVista(categoria.ToString());
    //        }
    //    }
    //    else
    //    {
    //        vista.ActualizaVista(modelo.Producto.Consultar(nombre).ToString());
    //    }
    //}

    private List<String> ListarProductos()
    {
        List<String> lista = new();
        foreach (var producto in repository.ProductoRepository1.Productos)
        {
            lista.Add(producto.Nombre);
        }
        return lista;
    }

    //private void AnadirCategoria()
    //{
    //    vista.ActualizaVista("Introduce el nombre de la categoria: ");
    //    string nombre = Console.ReadLine(); //Deberia comprobar si la categoria ya existe
    //    if ((modelo.Categoria.Consultar(nombre) is null))
    //    {
    //        modelo.Categoria.Anadir(new Categoria(nombre));
    //    }
    //    else
    //    {
    //        vista.ActualizaVista("La categoria introducida ya existe");
    //    }

    //    vista.ActualizaVista("categoria añadida satisfactoriamente");
    //}

    //private void AnadirProducto()
    //{
    //    vista.ActualizaVista("Introduce el nombre del producto: ");
    //    string nombre = Console.ReadLine();
    //    if ((modelo.Producto.Consultar(nombre) is null))
    //    {
    //        vista.ActualizaVista("Introduce una breve descripción del producto: ");
    //        string desc = Console.ReadLine();
    //        vista.ActualizaVista("Introduce el precio del producto: ");
    //        string precioStr = Console.ReadLine();
    //        if (double.TryParse(precioStr, out double prec))
    //        {
    //            vista.ActualizaVista("Introduce la categoria del producto (en blanco para predeterminado): ");
    //            string strCategoria = Console.ReadLine();
    //            Categoria categoria = null;

    //            if (string.IsNullOrEmpty(strCategoria))
    //            {
    //                categoria = modelo.Categoria.Categorias[0];
    //            }
    //            else if (!(modelo.Categoria.Consultar(strCategoria) is null))
    //            {
    //                categoria = modelo.Categoria.Consultar(strCategoria);
    //            }
    //            else
    //            {
    //                vista.ActualizaVista("La categoria introducida no existe");
    //            }

    //            if (categoria != null)
    //            {
    //                modelo.Producto.Anadir(new Producto(nombre, desc, prec, categoria));
    //                vista.ActualizaVista("Producto añadido satisfactoriamente");

    //            }
    //        }
    //        else
    //        {
    //            vista.ActualizaVista("El precio introducido no es válido.");
    //        }
    //    }
    //    else
    //    {
    //        vista.ActualizaVista("El producto ya existe");
    //    }
    //}
}