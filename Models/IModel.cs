using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.dataclases;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;

internal interface IModel
{
    void AnadirProducto(Producto product);
    void AnadirCategoria(Categoria categoria);
    void ModificarProducto(int id, Producto product);
    void ActualizarCategoriaDeProductos(int ctid);
    void ModificarCategoria(int id, Categoria categoria);
    Producto ConsultarProducto(int id);
    Categoria ConsultarCategoria(int id);
    Producto ConsultarNombreProducto(string nombre);
    Categoria ConsultarNombreCategoria(string nombre);
    void BorrarProducto(int id);
    void BorrarCategoria(int id);
    int BuscarPosicionProducto(int id);
    int BuscarPosicionCategoria(int id);
    Producto BuscarProductoDesdePosicion(int pos);
    Categoria BuscarCategoriaDesdePosicion(int pos);
    bool ExisteCategoria(string nombre);
    List<String> listarProductosPorCategoria(Categoria categoria);
    List<String> ListarProductos();
    List<String> ListarCategorias();
    void GuardarEnXML();
}
