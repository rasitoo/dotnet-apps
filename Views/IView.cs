namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Views;

internal interface IView
{
    event EventHandler ListBoxItemSelected;
    event EventHandler productoAnadir_Click;
    event EventHandler buttonEliminar_Click;
    event EventHandler buttonModificar_Click;

    public string DisplayId { get; set; }
    public string DisplayNombre { get; set; }
    public object DisplayPertenecientes { get; set; }
    public string DisplayPertenencia { get; set; }
    public string DisplayPrecio { get; set; }
    string SelectedItem { get; }
    public string DisplayDescripcion { get; set; }
    void cambiarLista(List<String> lista);
}
