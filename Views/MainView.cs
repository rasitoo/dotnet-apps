using P03_02_DI_Contactos_TAPIADOR_rodrigo.Presenters;
using System.Collections.Generic;


namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Views;

public partial class MainView : Form, IView
{
    public int SelectedItem => listBox1.SelectedIndex;
    public int SelectedProductoPerteneciente => listBoxInfo.SelectedIndex;

    public string DisplayId { get => textBoxId.Text; set => textBoxId.Text = value; }
    public string DisplayNombre { get => textBoxNombre.Text; set => textBoxNombre.Text = value; }
    public string DisplayPertenencia { get => textBoxInfo.Text; set => textBoxInfo.Text = value; }
    public List<String> DisplayPertenecientes { set => listBoxInfo.DataSource = value; }
    public string DisplayPrecio { get => textBoxPrecio.Text; set => textBoxPrecio.Text = value; }
    public string DisplayDescripcion { get => textBoxDesc.Text; set => textBoxDesc.Text = value; }
    public List<String> DisplayListaGeneral { set => listBox1.DataSource = value; }
    public bool InterfazProductos { get; set; }

    public event EventHandler ListBoxItemSelected;
    public event EventHandler ListBoxInfoItemSelected;
    public event EventHandler ListBoxInfoItemClicked;
    public event EventHandler productoAnadir_Click;
    public event EventHandler categoriaAnadir_Click;
    public event EventHandler buttonEliminar_Click;
    public event EventHandler buttonModificar_Click;
    public event EventHandler productosToolStripMenuItem_Click;
    public event EventHandler categoriasToolStripMenuItem_Click;



    public MainView()
    {
        InitializeComponent();
        AttachEventHandlers();
        listBoxInfo.Visible = false;
        textBoxId.Enabled = false;
        InterfazProductos = true;
    }
    private void AttachEventHandlers()
    {
        listBox1.SelectedIndexChanged += (sender, e) => ListBoxItemSelected?.Invoke(sender, e);
        listBoxInfo.SelectedIndexChanged += (sender, e) => ListBoxInfoItemSelected?.Invoke(sender, e);
        productoAnadir.Click += (sender, e) => productoAnadir_Click?.Invoke(sender, e);
        categoríaAnadir.Click += (sender, e) => categoriaAnadir_Click?.Invoke(sender, e);
        buttonEliminar.Click += (sender, e) => buttonEliminar_Click?.Invoke(sender, e);
        eliminarToolStripMenuItem.Click += (sender, e) => buttonEliminar_Click?.Invoke(sender, e);
        buttonModificar.Click += (sender, e) => buttonModificar_Click?.Invoke(sender, e);
        productosToolStripMenuItem.Click += (sender, e) => productosToolStripMenuItem_Click?.Invoke(sender, e);
        categoriasToolStripMenuItem.Click += (sender, e) => categoriasToolStripMenuItem_Click?.Invoke(sender, e);
        listBoxInfo.Click += (sender, e) => ListBoxInfoItemClicked?.Invoke(sender, e);


    }

    public void interfazCategorias()
    {
        InterfazProductos = false;

        listBoxInfo.Visible = true;
        textBoxInfo.Visible = false;
        headerDesc.Visible = false;
        textBoxDesc.Visible = false;
        headerPrecio.Visible = false;
        textBoxPrecio.Visible = false;
        headerCategoria.Text = "Productos";

    }

    public void interfazProductos()
    {
        InterfazProductos = true;

        listBoxInfo.Visible = false;
        textBoxInfo.Visible = true;
        headerDesc.Visible = true;
        textBoxDesc.Visible = true;
        headerPrecio.Visible = true;
        textBoxPrecio.Visible = true;
        headerCategoria.Text = "Categoria";
    }


}

