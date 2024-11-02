using System.Windows.Forms;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Views;

internal interface IView
{
    event EventHandler ListBoxItemSelected;
    event EventHandler productoAnadir_Click;
    event EventHandler buttonEliminar_Click;
    event EventHandler buttonModificar_Click;
    event EventHandler productosToolStripMenuItem_Click;
    event EventHandler categoriasToolStripMenuItem_Click;
    event EventHandler ListBoxInfoItemClicked;
    event EventHandler categoriaAnadir_Click;
    event EventHandler guardarToolStripMenuItem_Click;




    public string DisplayId { get; set; }
    public string DisplayNombre { get; set; }
    public List<String> DisplayPertenecientes {  set; }
    public string DisplayPertenencia { get; set; }
    public string DisplayPrecio { get; set; }
    int SelectedItem { get; }
    int SelectedProductoPerteneciente { get; }
    public bool InterfazProductos { get; set; }

    public List<String> DisplayListaGeneral { set; }

    public string DisplayDescripcion { get; set; }
    void interfazCategorias();
    void interfazProductos();
}
