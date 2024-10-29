using P03_02_DI_Contactos_TAPIADOR_rodrigo.Presenters;


namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Views;

public partial class MainView : Form, IView
{
    internal MainPresenter Presenter { get; set; }
    public int SelectedItem => listBox1.SelectedIndex;
    public string DisplayId { get => textBoxId.Text; set => textBoxId.Text = value; }
    public string DisplayNombre { get => textBoxNombre.Text; set => textBoxNombre.Text = value; }
    public string DisplayPertenencia { get => textBoxInfo.Text; set => textBoxInfo.Text = value; }
    public object DisplayPertenecientes { get => listBoxInfo.DataSource; set => listBoxInfo.DataSource = value; }
    public string DisplayPrecio { get => textBoxPrecio.Text; set => textBoxPrecio.Text = value; }
    public string DisplayDescripcion { get => textBoxDesc.Text; set => textBoxDesc.Text = value; }

    public event EventHandler ListBoxItemSelected;
    public event EventHandler ListBoxInfoItemSelected;
    public event EventHandler productoAnadir_Click;
    public event EventHandler buttonEliminar_Click;
    public event EventHandler buttonModificar_Click;

    public MainView()
    {
        InitializeComponent();
        AttachEventHandlers();
        listBoxInfo.Visible = false;
        textBoxId.Enabled = false;
    }
    private void AttachEventHandlers()
    {
        listBox1.SelectedIndexChanged += (sender, e) => ListBoxItemSelected?.Invoke(sender, e);
        listBoxInfo.SelectedIndexChanged += (sender, e) => ListBoxInfoItemSelected?.Invoke(sender, e);
        productoAnadir.Click += (sender, e) => productoAnadir_Click?.Invoke(sender, e);
        buttonEliminar.Click += (sender, e) => buttonEliminar_Click?.Invoke(sender, e);
        eliminarToolStripMenuItem.Click += (sender, e) => buttonEliminar_Click?.Invoke(sender, e);
        buttonModificar.Click += (sender, e) => buttonModificar_Click?.Invoke(sender, e);
    }
    public void cambiarLista(List<string> lista)
    {
        listBox1.DataSource = lista;
    }
}

