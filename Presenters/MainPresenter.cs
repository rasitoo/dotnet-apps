using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;
using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.dataclases;
using P03_02_DI_Contactos_TAPIADOR_rodrigo.Views;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Presenters;

internal class MainPresenter : IPresenter
{
    private IView _view;
    private IModel _model;

    public MainPresenter(IView view, IModel model)
    {
        this._view = view;
        this._model = model;
        view.DisplayListaGeneral = _model.ListarProductos();
        _view.ListBoxItemSelected += OnListBoxItemSelected;
        _view.productoAnadir_Click += OnProductoAnadir_Click;
        _view.categoriaAnadir_Click += OncategoriaAnadir_Click;
        _view.buttonEliminar_Click += OnButtonEliminar_Click;
        _view.buttonModificar_Click += OnButtonModificar_Click;
        _view.productosToolStripMenuItem_Click += OnproductosToolStripMenuItem_Click;
        _view.categoriasToolStripMenuItem_Click += OncategoriasToolStripMenuItem_Click;
        _view.ListBoxInfoItemClicked += OnListBoxInfoItemClicked;
    }
    private void OncategoriaAnadir_Click(object? sender, EventArgs e)
    {
        Categoria ct = new Categoria("null");
        _model.AnadirCategoria(ct);
        _view.interfazCategorias();
        _view.DisplayListaGeneral = _model.ListarCategorias();
        MostrarCategoria(ct);
    }
    private void OnProductoAnadir_Click(object sender, EventArgs e)
    {
        Producto pr = new Producto("null", "null", 0.0, -1);
        _model.AnadirProducto(pr);
        _view.DisplayListaGeneral = _model.ListarProductos();
        MostrarProducto(pr);
    }
    private void OnListBoxInfoItemClicked(object? sender, EventArgs e)
    {
        int selectedItem = _view.SelectedProductoPerteneciente;
        _view.DisplayListaGeneral = _model.ListarProductos();
        _view.interfazProductos();
        Producto pr = _model.BuscarProductoDesdePosicion(selectedItem);
        MostrarProducto(pr);
    }
    private void OnListBoxItemSelected(object sender, EventArgs e)
    {
        int selectedItem = _view.SelectedItem;

        if (_view.InterfazProductos)
        {
            Producto pr = _model.BuscarProductoDesdePosicion(selectedItem);
            MostrarProducto(pr);
        }
        else
        {
            Categoria ct = _model.BuscarCategoriaDesdePosicion(selectedItem);
            MostrarCategoria(ct);
        }
    }
    private void OnButtonEliminar_Click(object sender, EventArgs e)
    {
        if (_view.InterfazProductos)
        {
            _model.BorrarProducto(_view.SelectedItem);
            _view.DisplayListaGeneral = _model.ListarProductos();
        }
        else
        {
            int ctid = _model.BuscarCategoriaDesdePosicion(_view.SelectedItem).Id;
            _model.BorrarCategoria(_view.SelectedItem);
            _view.DisplayListaGeneral = _model.ListarCategorias();
            _model.ActualizarCategoriaDeProductos(ctid);
        }
    }



    private void OnButtonModificar_Click(object sender, EventArgs e)
    {
        if (_view.InterfazProductos)
        {
            Categoria ct = _model.ConsultarNombreCategoria(_view.DisplayPertenencia);
            if (!(ct is null))
            {
                _model.ModificarProducto(int.Parse(_view.DisplayId), new Producto(_view.DisplayNombre, _view.DisplayDescripcion, Double.Parse(_view.DisplayPrecio), ct.Id));
                _view.DisplayListaGeneral = _model.ListarProductos();
            }
            else
            {
                if (_view.DisplayPertenencia.Equals("null") || _view.DisplayPertenencia.Equals(""))
                {
                    MessageBox.Show("La categoría no puede estar vacía o con valor null", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult resultado = MessageBox.Show("La categoría introducida no existe, ¿desea crearla?", "Consulta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (resultado == DialogResult.OK)
                    {
                        _model.AnadirCategoria(new Categoria(_view.DisplayPertenencia));
                        ct = _model.ConsultarNombreCategoria(_view.DisplayPertenencia);
                        _model.ModificarProducto(int.Parse(_view.DisplayId), new Producto(_view.DisplayNombre, _view.DisplayDescripcion, Double.Parse(_view.DisplayPrecio), ct.Id));
                        _view.DisplayListaGeneral = _model.ListarProductos();
                    }
                }
            }
        }
        else
        {
            if (_view.DisplayNombre.Equals("null") || _view.DisplayNombre.Equals(""))
            {
                MessageBox.Show("La categoría no puede estar vacía o con valor null", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                if (_model.ExisteCategoria(_view.DisplayNombre))
                {
                    MessageBox.Show("Ya existe una categoría con ese nombre", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else
                {
                    _model.ModificarCategoria(int.Parse(_view.DisplayId), new Categoria(_view.DisplayNombre));
                    _view.DisplayListaGeneral = _model.ListarCategorias();
                }
            }
        }
    }
    private void MostrarProducto(Producto pr)
    {
        if (!(pr.IdCategoria == -1))
        {
            _view.DisplayId = pr.Id.ToString();
            _view.DisplayNombre = pr.Nombre;
            _view.DisplayDescripcion = pr.Descripcion;
            _view.DisplayPrecio = pr.Precio.ToString();
            _view.DisplayPertenencia = _model.ConsultarCategoria(pr.IdCategoria).Nombre;
        }
        else
        {
            _view.DisplayId = pr.Id.ToString();
            _view.DisplayNombre = pr.Nombre;
            _view.DisplayDescripcion = pr.Descripcion;
            _view.DisplayPrecio = pr.Precio.ToString();
            _view.DisplayPertenencia = _model.ConsultarCategoria(pr.IdCategoria).Nombre;
        }
    }
    private void MostrarCategoria(Categoria ct)
    {
        if (!(ct is null))
        {
            _view.DisplayId = ct.Id.ToString();
            _view.DisplayNombre = ct.Nombre;
            _view.DisplayPertenecientes = _model.listarProductosPorCategoria(ct);
        }
    }

    private void OncategoriasToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        _view.DisplayListaGeneral = _model.ListarCategorias();
        _view.interfazCategorias();
    }

    private void OnproductosToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        _view.DisplayListaGeneral = _model.ListarProductos();
        _view.interfazProductos();
    }


}