namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;

public class Producto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public Categoria Categoria { get; set; }
    public int Id { get ; set ; }
    public override string ToString()
    {
        return
            $"""
             
             {nameof(Nombre)}: {Nombre}
                 {nameof(Descripcion)}: {Descripcion}
                 {nameof(Precio)}: {Precio}
                 {nameof(Categoria)}:
                    {Categoria.ToString()}
             
             """;
    }

    public Producto(string nombre, string descripcion, double precio, Categoria? categoria)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        Categoria = categoria;
    }

}
